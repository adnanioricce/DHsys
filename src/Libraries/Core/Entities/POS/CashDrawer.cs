using Core.Entities.POS;
using Core.Entities.Inventory;
using Core.Interfaces.POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.POS
{
    /// <summary>
    /// domain representation of a cash drawer.
    /// </summary>
    public class CashDrawer : BaseEntity
    {
        public decimal StartCashAmount { get; private set; }
        public CashDrawerState State { get; private set; } = CashDrawerState.Closed;
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public CashDrawer(decimal totalCashAmountAvailable)
        {
            StartCashAmount = totalCashAmountAvailable;
            State = CashDrawerState.Closed;
        }
        public virtual void Open(ICashDrawerMediator drawer)
        {
            State = drawer.Open() ? CashDrawerState.Open : State;
        }
        public virtual void Close(ICashDrawerMediator drawer)
        {
            State = drawer.Close() ? CashDrawerState.Closed : State;
        }        
        public void PerformTransaction(Transaction transaction)
        {
            this.Transactions.Add(transaction);
            StartCashAmount -= transaction.AmountIn - transaction.Change;
        }
    }
    public enum CashDrawerState
    {
        Closed, 
        Open        
    }
}
