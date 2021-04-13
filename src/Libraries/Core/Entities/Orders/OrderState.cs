namespace Core.Entities.Orders
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