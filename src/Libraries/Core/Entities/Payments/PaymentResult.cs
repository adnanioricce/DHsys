using System;

namespace Core.Entities.Payments
{
    public class PaymentResult
    {
        public int PaymentId { get; set; }
        public string Externalid { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal Change { get; set; }
        public decimal AmountCharged { get; set; }
        private PaymentResult(Payment payment,PaymentStatus status)
        {
            PaymentId = payment.Id;
            Externalid = payment.ExternalId;            
            Change = payment.NeededValue - payment.ReceivedValue;
            AmountCharged = payment.ReceivedValue;
            PaymentStatus = status;
        }
        private PaymentResult(PaymentStatus status,decimal change,decimal valueIssued)
        {
            PaymentStatus = status;
            Change = change;
            AmountCharged = valueIssued;
        }
        public static PaymentResult Create(Payment payment)
        {
            if (payment.ReceivedValue >= payment.NeededValue)
            {
                return PaymentResult.Paid(payment);
            }
            else if (payment.ReceivedValue < payment.NeededValue)
            {
                return PaymentResult.PartiallyPaid(payment);
            }
            else if (payment.ReceivedValue <= 0)
            {
                return PaymentResult.ZeroOrNegative();
            }
            else
            {
                return PaymentResult.Failed();
            }
        }

        public static PaymentResult ZeroOrNegative()
        {
            return new PaymentResult(PaymentStatus.ZeroOrNegative,change:0.0m,valueIssued:0.0m);            
        }

        public static PaymentResult Paid(Payment payment)
        {
            return new PaymentResult(payment,PaymentStatus.Paid);
        }
        public static PaymentResult Pending(Payment payment) => new PaymentResult(payment,PaymentStatus.Pending);        
        public static PaymentResult PartiallyPaid(Payment payment)
        {
            return new PaymentResult(payment,PaymentStatus.PartiallyPaid);
        }
        public static PaymentResult Failed(){
            return new PaymentResult(PaymentStatus.Failed,change:0.0m,valueIssued:0.0m);
        }
    }
}