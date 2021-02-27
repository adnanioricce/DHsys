using System;
using System.Threading.Tasks;
using Core.Entities.Payments;
using Core.Entities.User;
using Core.Interfaces;
using Core.Interfaces.Payments;
using Core.Models;

namespace Application.Services.Payments
{
    public class InHandsProcessor : IPaymentProcessor
    {
        protected readonly IRepository<Payment> _paymentRepository;        
        protected readonly IRepository<Customer> _customerRepository;
        public InHandsProcessor(IRepository<Payment> paymentRepository,IRepository<Customer> customerRepository)
        {
            _paymentRepository = paymentRepository;
            _customerRepository = customerRepository;
        }        

        public Task<BaseResult<object>> ProcessAsync<PaymentRequest>(PaymentRequest request)
        {
            throw new NotImplementedException();
        }
        
    }
    public class PaymentRequest
    {
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentRequest(Customer customer,Payment payment,PaymentMethod paymentMethod)
        {
            Customer = customer;
            Payment = payment;
            PaymentMethod = paymentMethod;
        }
    }
}