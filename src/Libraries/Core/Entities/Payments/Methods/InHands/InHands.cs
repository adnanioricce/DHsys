using Core.Entities.Payments.Methods;
using System.Threading.Tasks;
using Core.Interfaces.Payments;
using Core.Models.Results;

namespace Core.Entities.Payments.Methods.InHands
{
    public class InHands : PaymentMethod
    {
        protected readonly IPaymentProcessor _paymentProcessor;
        private InHands() : base() { }
        public InHands(bool acceptsPartialPayment,IPaymentProcessor paymentProcessor)
        {
            AcceptsPartialPayments = acceptsPartialPayment;
            _paymentProcessor = paymentProcessor;
        }       
    }
    public class InHandsChargeRequest : IPaymentCommand
    {        
        public Payment Payment { get; private set; }
        public decimal ReceivedValue { get; private set; }
        public InHandsChargeRequest(decimal receivedValue,Payment payment)
        {            
            Payment = payment;            
            ReceivedValue = receivedValue;
        }

        public async Task<Result<Payment>> SendAsync()
        {
            await Task.Delay(0);
            InHands inhandsMethod = Payment.Method as InHands;
            if(inhandsMethod is null)
                return Result<Payment>.Failed(new [] {"Payment does not accept In-Hands payment" },Payment);            
            if(this.Payment.NeededValue == ReceivedValue)
                return Result.Succeed<Payment>(Payment.Create(this.Payment.Method,this.Payment.Customer,ReceivedValue,this.Payment.NeededValue));
            if(this.Payment.ReceivedValue <= 0)
                return Result<Payment>.Failed(new [] {"Received payment is too low to be considered"},Payment);
            if(this.Payment.NeededValue != ReceivedValue && inhandsMethod.AcceptsPartialPayments)
                return Result<Payment>.Succeed(Payment.Create(this.Payment.Method,this.Payment.Customer,ReceivedValue,this.Payment.NeededValue));

            return Result<Payment>.Failed(new [] {"The payment passed is invalid, and cannot be processed" },this.Payment);
        }
    }
}