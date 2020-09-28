using Core.Entities.Catalog;
using FluentValidation;
using System;

namespace Core.Validations
{
    public class ProductStockEntryValidator : BaseValidator<ProductStockEntry>
    {
        public ProductStockEntryValidator()
        {
            RuleFor(p => p)
                .Must(p => p.Product.PrescriptionNeeded ? !string.IsNullOrEmpty(p.LotCode) : true)                
                    .WithMessage("Products that need prescription should contain it's lot code");
            RuleFor(p => p.ProductMaturityDate)
                .GreaterThanOrEqualTo(p => DateTime.Now.AddDays(7))
                    .When(p => p.Product.PrescriptionNeeded)
                        .WithMessage("That maturity date is too close of the allowed date range");
        }
    }
}
