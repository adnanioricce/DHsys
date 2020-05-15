using System.Collections.Generic;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBillingService
    {
        void AddBilling(Billing billing);
        IEnumerable<Billing> GetUnpaidBillings(int? limit);        
    }
}