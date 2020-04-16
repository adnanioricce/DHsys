using Core.Entities.Stock;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class StockService : IStockService
    {
        private readonly IRepository<StockEntry> _stockEntryRepository;
        public StockService(IRepository<StockEntry> stockEntryRepository)
        {
            _stockEntryRepository = stockEntryRepository;
        }

        public void AddMultipleStockEntries(IEnumerable<StockEntry> stockentries)
        {
            throw new NotImplementedException();
        }
    }
}
