using Core.Entities.User;

namespace Core.Entities.Payments.Methods
{
    public class CreditCardMethod : PaymentMethod
    {        
        private CreditCardMethod()
        {
            UniqueCode = "credit_card_{GUID}";
        }
        public CreditCardMethod(Customer owner,string provider,string providerUrl)
        {
            Owner = owner;
            Provider = provider;
            ProviderUrl = providerUrl;
        }
        public Customer Owner { get; private set; }
        public string Provider { get; private set; }
        public string ProviderUrl { get; private set; }
    }
}