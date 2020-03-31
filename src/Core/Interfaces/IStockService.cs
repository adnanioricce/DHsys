using Core.Entities.Stock;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IStockService
    {
        void AddMultipleStockEntries(IEnumerable<Stockentries> stockentries);
    }
}
