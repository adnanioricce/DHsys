using Core.Entities.Catalog;
using Core.Entities.Stock;
using System;

namespace DAL.Seed
{
    public class StockEntrySeed : IDataObjectSeed<StockEntry>
    {
        public StockEntry GetSeedObject()
        {
            var stockEntry = new StockEntry();
            stockEntry.CreatedAt = DateTimeOffset.UtcNow;
            stockEntry.NfNumber = Guid.NewGuid().ToString();
            stockEntry.NfEmissionDate = DateTime.Now.AddDays(-2);            
            //Warning:Related Product entities should exists before inserting a new StockEntry.            
            return stockEntry;
        }
    }
}
