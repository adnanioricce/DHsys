namespace Core.Entities.Stock
{
    public class DrugStockEntry : BaseEntity
    {
        public int DrugId { get; set; }
        public virtual Drug Drug { get; set; }
        public int StockEntryId { get; set; }
        public virtual StockEntry StockEntry { get; set; }
    }
}