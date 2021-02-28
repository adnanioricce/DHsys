namespace Core.Entities.Financial
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