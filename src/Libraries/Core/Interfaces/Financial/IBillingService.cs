using System.Collections.Generic;
using Core.Entities.Financial;
using Core.Results;

namespace Core.Interfaces
{
    public interface IBillingService
    {
        Result<Billing> AddBilling(Billing billing);
        Result<IEnumerable<Billing>> AddBillingsFromFile(string csvFilePath);
        IEnumerable<Billing> GetUnpaidBillings(int? limit);
        IEnumerable<Billing> GetBillings(int? limit);
        IEnumerable<Billing> GetBillingsByBeneficiaryName(string beneficiaryName);
    }
}