using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Interfaces;
namespace Core.Services
{
    public class BillingService : IBillingService
    {
        private readonly IRepository<Billing> _billingRepository;        
        public BillingService(IRepository<Billing> billingRepository)
        {
            _billingRepository = billingRepository;            
        }
        public void AddBilling(Billing billing)
        {
            _billingRepository.Add(billing);
            _billingRepository.SaveChanges();
        }
        public IEnumerable<Billing> GetUnpaidBillings(int? limit = null)
        {
            return _billingRepository.Query()
            .Where(b => !b.IsPaid)
            .Take(limit is null ? 100 : limit.Value);            
        }        
        
    }
}