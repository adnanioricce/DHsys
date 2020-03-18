namespace Core.Interfaces
{
    public interface IBillingService
    {
        void AddConta(Billing billing);
        IEnumerable<Billing> GetUnpaidBillings(int limit);
        
    }
}