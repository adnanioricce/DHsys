using Core.Entities.Catalog;
using FluentValidation;
using System;

namespace Core.Validations
{
    public class ProductStockEntryValidator : BaseValidator<ProductStockEntry>
    {
        public ProductStockEntryValidator()
        {
            //TODO: Merge Drug and Product Models, to avoid problems with validation,relations and etc
            //TODO: Add validation for drugs that need prescription always include lot code and maturity date
        }
    }
}
