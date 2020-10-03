using Core.Entities.Catalog;
using Core.Entities.Stock;

namespace Core.Validations
{
    public class StockEntryValidator : BaseValidator<StockEntry>
    {
        public StockEntryValidator()
        {
            RuleForEach(st => st.Items).SetValidator(new ProductStockEntryValidator());
            
        }       
    }
}
