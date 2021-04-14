using Core.Interfaces.POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.POS
{
    /// <summary>
    /// domaing representation of a cash drawer.
    /// </summary>
    public class CashDrawer : BaseEntity
    {
        public decimal TotalCashAmountAvailable { get; private set; }
        public CashDrawerState State { get; private set; } = CashDrawerState.Closed;
        public virtual void Open(ICashDrawerMediator drawer)
        {
            State = drawer.Open() ? CashDrawerState.Open : State;
        }
        public virtual void Close(ICashDrawerMediator drawer)
        {
            State = drawer.Close() ? CashDrawerState.Closed : State;
        }

    }
    public enum CashDrawerState
    {
        Closed, 
        Open        
    }
}
