using Core.Entities;
using Core.Interfaces;
using Core.Models;
using Core.Models.Results;
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
        public virtual Result<T> IsValid(T obj)
        {
            var validateResult = Validate(obj);
            if (validateResult.IsValid)
            {
                return new Result<T>
                {
                    Errors = validateResult.Errors.Select(v => new Error(v.ErrorCode,FormatToErrorMessage(v),true)),
                    Success = validateResult.IsValid,
                    Value = obj,
                };
            }
            
            return new Result<T>
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
