using System.Collections.Generic;
using Core.Entities.Financial;
using Core.Models;

namespace Core.Interfaces
{
    public interface IBillingService
    {
        BaseResult<Billing> AddBilling(Billing billing);
        IEnumerable<Billing> GetUnpaidBillings(int? limit);
        IEnumerable<Billing> GetBillingsByBeneficiaryName(string beneficiaryName);
    }
}