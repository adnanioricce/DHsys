namespace Core.Entities.Payments
{
    using System.Threading.Tasks;
    using global::Core.Interfaces.Payments;
    using global::Core.Models;
    using System;
    using global::Core.Entities.Payments.Methods;

    public abstract class PaymentMethod : BaseEntity
    {       
        protected PaymentMethod()
        {

        }
        public string Name { get; set; }        
        public bool AcceptsPartialPayments { get; protected set; }                        
        
    }
}