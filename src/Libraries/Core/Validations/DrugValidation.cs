using Core.Entities.Catalog;
using FluentValidation;

namespace Core.Validations
{
    public class DrugValidation : BaseValidator<Drug>
    {
        protected readonly BaseValidator<Product> _productValidator;
        public DrugValidation(ProductValidator productValidator)
        {
            _productValidator = productValidator;
        }
        public DrugValidation()
        {
            //TODO:
        }
    }
}
