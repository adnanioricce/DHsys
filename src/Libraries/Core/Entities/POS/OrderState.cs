namespace Core.Entities.POS
{
    public enum OrderState
    {
        New,
        Preparing,
        PartiallyPaid,
        Paid,
        Failed,
        Cancelled
    }
}