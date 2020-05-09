using Core.Entities.Catalog;
using Core.Entities.Stock;
using Core.Models.ApplicationResources.Catalog;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IStockService
    {
        void AddMultipleStockEntries(IEnumerable<StockEntry> stockentries);
        void AddStockEntry(StockEntry stockentry);
        StockEntry GetByNfCode(string nfNumber);
        IEnumerable<Drug> GetItemsWithPriceChanged(IEnumerable<Drug> drugs);
    }
}
