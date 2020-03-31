using Core.Entities.Stock;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class StockService : IStockService
    {
        private readonly IRepository<Stockentries> _stockEntryRepository;
        public StockService(IRepository<Stockentries> stockEntryRepository)
        {
            _stockEntryRepository = stockEntryRepository;
        }

        public void AddMultipleStockEntries(IEnumerable<Stockentries> stockentries)
        {
            throw new NotImplementedException();
        }
    }
}
