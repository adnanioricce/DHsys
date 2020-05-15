using Core.Entities;
using FluentValidation;
using System;
using System.Linq;

namespace Core.Validations
{
    public class BillingValidator : BaseValidator<Billing>
    {
        public BillingValidator()
        {
            RuleFor(c => c.BeneficiaryName)
                .NotNull()
                    .WithMessage("NomeEmpresa can't be null")
                .Length(1, 250)
                    .WithMessage("the NomeEmpresa should have at least 1 character and be less than 250 characters");
            RuleFor(c => c.EndDate)               
                .Must(c =>
                {                                     
                    return c.HasValue && c.Value >= DateTime.MinValue;
                }).WithMessage("EndDate format is invalid, check if value is less than should be,if you entered it correctly or if is null")
                .NotNull()
                    .WithMessage("you can't pass a null value to DataDeVencimento");                                            
            RuleFor(c => c.Price)
                .GreaterThan(0)
                    .WithMessage("bill value should be greater than 0")
                .NotNull()
                    .WithMessage("bill value can't be null");
                
        }                
    }
}
