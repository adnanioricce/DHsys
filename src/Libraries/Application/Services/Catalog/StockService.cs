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
            //TODO:Add Validation         
            var existingAndNewEntries = stockentries.Select(st => (Existing:GetByNfCode(st.NfCode),Given:st));            
            var newEntries = stockentries.Where(st => st.Existing is null)
                                         .Select(st => st.Given);
            var existingEntries = stockentries.Where( => !(st.Existing is null));           
            foreach(var entry in existingEntries){                                
                entry.Existing.Drugs.AddRange(entry.Given.Drugs);                
            }
            _stockEntryRepository.AddRange(newEntries);
            _stockEntryRepository.AddRange(existingEntries.Select(st => st.Existing));
            _stockEntryRepository.SaveChanges();
        }
        public void AddStockEntry(StockEntry stockentry)
        {
            //TODO:Add Validation
            _stockEntryRepository.Add(stockentry);
        }
        public StockEntry GetByNfCode(string nfCode)
        {
            return _stockEntryRepository.Query()
            .Where(s => string.Equals(s.NfCode,nfCode,StringComparison.OrdinalIgnoreCase))
            .FirstOrDefault();
        }
        
    }
}
