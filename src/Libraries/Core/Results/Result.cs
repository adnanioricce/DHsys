using Core.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Results
{    
    public sealed record Result<T>
    {
        public IList<Error> Errors { get; } = new List<Error>();                
        public T Value { get; }
        public bool Success => !Errors.Any();        
        public Result(T value,IEnumerable<Error> errors)
        {
            Value = value;
            foreach (var error in errors)
            {
                Errors.Add(error);
            }
        }   
        public static Result<T> Fail(T value,params Error[] errors)
            => new Result<T>(value,errors);
        public static Result<T> Ok(T value)
            => new Result<T>(value,Enumerable.Empty<Error>());
    }    
}
namespace Core.Results.Extensions
{
    public static class RailwayExtensions
    {
        public static Result<T> Combine<T>(this Result<T> result,Result<T> outroResult)
        {          
            var errors = result.Errors.Concat(outroResult.Errors);
            var novoResultado = Result<T>.Fail(result.Value,errors.ToArray());            
            return novoResultado;
        }        
        public static Result<TOut> Bind<TIn,TOut>(this Result<TIn> input,Func<TIn,Result<TOut>> switchFunction)
        {
            return 
                input.Success
                    ? switchFunction(input.Value)
                    : Result<TOut>.Fail(default,input.Errors.ToArray());
        }
        public static Result<TOut> Map<TIn,TOut>(this Result<TIn> input,Func<TIn,TOut> mapFunction)
        {
            return
                input.Success
                    ? Result<TOut>.Ok(mapFunction(input.Value))
                    //TODO: Change default to a option type maybe?
                    : Result<TOut>.Fail(default,input.Errors.ToArray());
        }
        public static Result<TOut> DoubleMap<TIn,TOut>(
            this Result<TIn> input,
            Func<TIn,TOut> successMapFunction,
            Func<TIn,TOut> failureMapFunction)
        {
            return 
                input.Success
                ? Result<TOut>.Ok(successMapFunction(input.Value))
                : Result<TOut>.Fail(failureMapFunction(input.Value),input.Errors.ToArray());
        }
        public static Result<TIn> Tee<TIn>(
            this Result<TIn> input,
            Action<TIn> deadEndFunction)
        {
            if(input.Success)
                deadEndFunction(input.Value);
            return input;
        }
        public static Result<TOut> Succeed<TIn,TOut>(
            this Result<TIn> input,
            Func<TIn,TOut> trackFunction)
        {
            return Result<TOut>.Ok(trackFunction(input.Value));
        }
        public static Result<TOut> Failed<TIn,TOut>(
            this Result<TIn> input,
            Func<TIn,TOut> trackFunction)
        {
            return Result<TOut>.Fail(trackFunction(input.Value),input.Errors.ToArray());
        }
        public static Result<TOut> TryCatch<TIn,TOut>(this Result<TIn> input,Func<TIn,TOut> singleTrackFunc)
        {
            try
            {
                return input.Success
                    ? Result<TOut>.Ok(singleTrackFunc(input.Value))
                    : Result<TOut>.Fail(default,input.Errors.ToArray());
            }
            catch(Exception ex)
            {
                var error = new ExceptionError(ex);
                return Result<TOut>.Fail(default,error);
            }
        }        
    }
}