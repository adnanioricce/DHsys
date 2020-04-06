using Core.Interfaces;
namespace Services.Billing
{
    public class BillingService : IBillingService
    {
        private readonly IRepository<Billing> billingRepository;
        private readonly IEmailSender _emailSender;
        public BillingService(IRepository<Billing> _billingRepository,IEmailSender emailSender)
        {
            _billingRepository = billingRepository;
            _emailSender = emailSender;
        }
        public void AddBilling(Billing billing)
        {
            _billingRepository.Add(billing);
            _billingRepository.SaveChanges();
        }
        public IEnumerable<Billing> GetUnpaidBillings(int limit = null)
        {
            return _billingRepository.Query()
                .Where(b => !b.IsPaid)
                .Take(limit is null ? 100 : limit)
                .ToList();
        }
        public IEnumerable<Billing> GetAllBillingsByBeneficiaryId(int beneficiaryId)
        {
            return _billingRepository.Query().Where(b => b.BeneficiaryId == beneficiaryId);
        } 
        
    }
}