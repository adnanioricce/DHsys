using Core.Entities;
using Core.Entities.Catalog;
using Core.Entities.POS;

namespace Core.Entities.Inventory
{
    public class Transaction : BaseEntity
    {
        public Transaction(POSOrder order,CashDrawer cashDrawer, decimal change)
        {
            OrderId = order.Id;
            CashDrawer = cashDrawer;
            AmountIn = order.OrderTotal;
            Change = change;
        }
        public Transaction(CashDrawer cashDrawer,decimal amountIn,decimal change)
        {
            CashDrawer = cashDrawer;
            AmountIn = amountIn;
            Change = change;
        }
        public int? OrderId { get; private set; }
        public CashDrawer CashDrawer { get; private set; }
        public decimal AmountIn { get; private set; }
        public decimal Change { get; private set; }
        
        
    }
}