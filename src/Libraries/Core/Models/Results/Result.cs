using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Models.Results
{
    //!Possible replication of Application.Models.ApplicationResources.BaseResourceResponse
    public class Result 
    {
        protected Action<Result> _onSuccess;
        protected Action<Result> _onFailure;
        public IEnumerable<Error> Errors { get; set; } = new List<Error>();
        public bool Success { get; set; }
        public string SuccessMessage { get; set; }
        public virtual object Value { get; set; }
        
        public Result()
        {
            
        }
        protected static Result CreateSuccessResult(string message,object value)
        {
            return new Result{
                Success = true,
                SuccessMessage = message,
                Value = value
            };
        }
        protected static Result CreateFailResult(IEnumerable<string> errors,object value)
        {
            return new Result{
                Errors = errors.Select(e => new Error(e)),
                Success = false,                
                Value = value
            };
        }
        public static Result Failed(string[] messages) => Result.CreateFailResult(messages,default);
        
        public static Result Succeed(string message) => Result.CreateSuccessResult(message,default);
        public static Result<T> Succeed<T>(string message,T value) => Result<T>.Succeed<T>(message,value);        
        public static Result<T> Succeed<T>(T value) => Result<T>.Succeed<T>("",value);
    }
    public class Result<T>  : Result
    {
        public Result()
        {

        }
        public static Result<T> Succeed(string successMessage, T value)
        {
            return new Result<T>
            {
                Success = true,
                SuccessMessage = successMessage,
                Value = value
            };
        }
        public static Result<T> Failed(IEnumerable<string> errors,T value)
        {
            return new Result<T>
            {
                Value = value,
                Errors = errors.Select(e => new Error(e)),
                Success = false
            };
        }
        public new T Value; 
        
    }    
}