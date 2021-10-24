using Core.Entities;
using Core.Results;
using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;
using System.Linq;

namespace Core.Validations
{
    public class BaseValidator<T> : AbstractValidator<T> where T : BaseEntity
    {
        public virtual Result<T> IsValid(T obj)
        {
            var validateResult = Validate(obj);
            if (validateResult.IsValid)
            {
                return Result<T>.Ok(obj);                
            }
            
            return Result<T>.Fail(obj,
                validateResult.Errors.Select(e => new Error(e.ErrorCode,e.ErrorMessage,true)).ToArray());            
            
        }        
        private string FormatToErrorMessage(ValidationFailure failure)
        {
            //?ValidationFailure has a overrided ToString() method, check it to see the difference between this and it's string
            return $@"The validation for {failure.PropertyName} 
                    with the value {failure.AttemptedValue} 
                    has given a error code {failure.ErrorCode} with the message '{failure.ErrorMessage}'";
        }
    }
}
