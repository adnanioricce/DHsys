using Core.Entities.Catalog;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Validations
{
    public class ProductValidator : BaseValidator<Product>
    {        
        public ProductValidator()
        {
            RuleFor(p => p.QuantityInStock)
                .GreaterThanOrEqualTo(0)
                .WithMessage("The quantity for stock given is not valid");
            RuleFor(p => p.ICMS)
                .Equal(18)
                .WithMessage("The ICMS Should be equal to 18");
            RuleFor(p => p.Ncm)
                .NotEmpty()
                .WithMessage("a Ncm wasn't set, please provide a value for the field");
            RuleFor(p => p.UniqueCode)
                .NotEmpty()
                .WithMessage("a Unique Code wasn't set, please, set a unique value for the field");
            RuleFor(p => p.MinimumStock)
                .GreaterThanOrEqualTo(1)
                .WithMessage("The minimum stock should be greater than or equal to 1");
            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("please provide a name for the product ");
        }        
    }
}
