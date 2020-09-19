using Core.Entities.Catalog;
using FluentValidation;

namespace Core.Validations
{
    public class DrugValidator : BaseValidator<Drug>
    {
        protected readonly BaseValidator<Product> _productValidator;
        public DrugValidator(ProductValidator productValidator)
        {
            _productValidator = productValidator;
        }
        public DrugValidator()
        {
            //TODO:
        }
    }
}
