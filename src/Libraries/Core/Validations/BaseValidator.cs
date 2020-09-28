using Core.Entities;
using Core.Interfaces;
using Core.Models;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validations
{
    public class BaseValidator<T> : AbstractValidator<T> where T : BaseEntity
    {
        public virtual BaseResult<T> IsValid(T obj)
        {
            var validateResult = Validate(obj);
            if (validateResult.IsValid)
            {
                return new BaseResult<T>
                {
                    Errors = validateResult.Errors.Select(FormatToErrorMessage),
                    Success = validateResult.IsValid,
                    Value = obj,
                };
            }
            
            return new BaseResult<T>
            {
                Success = validateResult.IsValid,
                Value = obj
            };
            
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
