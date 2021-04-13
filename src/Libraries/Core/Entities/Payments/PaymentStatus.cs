namespace Core.Entities.Payments
{
    public enum PaymentStatus
    {
        ZeroOrNegative,
        Pending,
        PartiallyPaid,
        Paid,        
        Failed
    }
}