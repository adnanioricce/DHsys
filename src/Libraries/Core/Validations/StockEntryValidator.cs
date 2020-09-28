using Core.Entities.Stock;
using Core.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using System;
//using System.Linq;
using System.Threading.Tasks;

namespace Core.Validations
{
    public class StockEntryValidator : BaseValidator<StockEntry>
    {
        public StockEntryValidator(ProductStockEntryValidator validator)
        {
            RuleForEach(st => st.Items).SetValidator(validator);
            
        }       
    }
}
