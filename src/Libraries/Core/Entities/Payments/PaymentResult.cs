namespace Core.Entities.Payments
{
    public class PaymentResult
    {        
        public PaymentStatus PaymentStatus { get; set; }
        public decimal Change { get; set; }
        public decimal ValueIssued { get; set; }
        public static PaymentResult Paid(decimal valueIssued)
        {
            return new PaymentResult{
                PaymentStatus = PaymentStatus.Paid,
                Change = 0.0m,
                ValueIssued = valueIssued
            };
        }
        public static PaymentResult PartiallyPaid(decimal change,decimal valueIssued)
        {
            return new PaymentResult {
                PaymentStatus = PaymentStatus.PartiallyPaid,
                Change = change,
                ValueIssued = valueIssued
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