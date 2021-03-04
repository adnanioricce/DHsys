using System;

namespace Core.Entities.Payments
{
    public class PaymentResult
    {        
        public PaymentStatus PaymentStatus { get; set; }
        public decimal Change { get; set; }
        public decimal ValueIssued { get; set; }
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
            return new PaymentResult
            {
                PaymentStatus = PaymentStatus.ZeroOrNegative,
                Change = 0.0m,
                ValueIssued = 0.0m
            };
        }

        public static PaymentResult Paid(Payment payment)
        {
            return new PaymentResult{
                PaymentStatus = PaymentStatus.Paid,
                Change = payment.NeededValue - payment.ReceivedValue,
                ValueIssued = payment.ReceivedValue
            };
        }
        public static PaymentResult PartiallyPaid(Payment payment)
        {
            return new PaymentResult {
                PaymentStatus = PaymentStatus.PartiallyPaid,
                Change = payment.NeededValue - payment.ReceivedValue,
                ValueIssued = payment.ReceivedValue
            };
        }
        public static PaymentResult Failed(){
            return new PaymentResult{
                PaymentStatus = PaymentStatus.Failed,
                Change = 0.0m,
                ValueIssued = 0.0m
            };
        }
    }
}