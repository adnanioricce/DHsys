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
            var drug = new DrugSeed().GetSeedObject();                  
            stockEntry.AddEntry(drug:(Drug)drug,maturityDate: DateTime.UtcNow,quantity: 1,lotCode: Guid.NewGuid().ToString());
            stockEntry.NfNumber = Guid.NewGuid().ToString();
            stockEntry.NfEmissionDate = DateTime.Now.AddDays(-2);
            var supplier = new SupplierSeed().GetSeedObject();
            stockEntry.Supplier = supplier;            
            return stockEntry;
        }
    }
}
