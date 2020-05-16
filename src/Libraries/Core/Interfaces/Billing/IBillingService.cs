using System.Collections.Generic;
using Core.Entities;
using Core.Models;

namespace Core.Interfaces
{
    public interface IBillingService
    {
        BaseResult<Billing> AddBilling(Billing billing);
        IEnumerable<Billing> GetUnpaidBillings(int? limit);        
    }
}