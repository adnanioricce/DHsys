using Core.Entities;
using FluentValidation;
using System;
using System.Linq;

namespace Core.Validations
{
    public class ContaValidator : AbstractValidator<Conta>
    {
        public ContaValidator()
        {
            RuleFor(c => c.NomeEmpresa)
                .NotNull()
                    .WithMessage("NomeEmpresa can't be null")
                .Length(1, 250)
                    .WithMessage("the NomeEmpresa should have at least 1 character and be less than 250 characters");
            RuleFor(c => c.DataDeVencimento)
                .MinimumLength(6)
                    .WithMessage("the field should have a min length of 6 characters")
                .MaximumLength(10)
                    .WithMessage("the field should have a max length of 10 characters")
                .Must(c =>
                {
                    DateTime.TryParse(c, out var result);                    
                    return result >= DateTime.MinValue;
                }).WithMessage("DataDeVencimento format is invalid, check if value is less than should be or if you entered it correctly")
                .NotNull()
                    .WithMessage("you can't pass a null value to DataDeVencimento");                                            
            RuleFor(c => c.Valor)
                .GreaterThan(0)
                    .WithMessage("bill value should be greater than 0")
                .NotNull()
                    .WithMessage("bill value can't be null");
                
        }        
        public bool IsValid(Conta conta)
        {
            var result = Validate(conta);
            if (result.Errors.Any())
            {
                Console.Out.WriteLine("validation of conta give the following errors:");
                foreach (var error in result.Errors) {
                    Console.Out.WriteLine(error);
                }
                return false;
            }
            return result.IsValid;
        }
    }
}
