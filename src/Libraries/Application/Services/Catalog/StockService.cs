using Core.Entities.Catalog;
using Core.Entities.Stock;
using Core.Interfaces;
using Core.Models.ApplicationResources.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class StockService : IStockService
    {
        private readonly IRepository<StockEntry> _stockEntryRepository;
        private readonly IDrugService _drugService; 
        public StockService(IRepository<StockEntry> stockEntryRepository,
        IDrugService drugService)
        {
            _stockEntryRepository = stockEntryRepository;
            _drugService = drugService;
        }

        public virtual void AddMultipleStockEntries(IEnumerable<StockEntry> stockentries)
        {   
            //TODO:Add Validation         
            var existingAndNewEntries = stockentries.Select(st => (Existing:GetByNfCode(st.NfNumber),Given:st));            
            var newEntries = existingAndNewEntries.Where(st => st.Existing is null)
                                         .Select(st => st.Given);
            var existingEntries = existingAndNewEntries.Where(st => !(st.Existing is null));           
            foreach(var (Existing, Given) in existingEntries){                                                
                Existing.AddDrugs(Given.Drugs);                
            }
            _stockEntryRepository.AddRange(newEntries);
            _stockEntryRepository.AddRange(existingEntries.Select(st => st.Existing));
            _stockEntryRepository.SaveChanges();
        }
        public virtual void AddStockEntry(StockEntry stockentry)
        {
            //TODO:Add Validation
            _stockEntryRepository.Add(stockentry);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nfNumber"></param>
        /// <returns></returns>
        public virtual StockEntry GetByNfCode(string nfNumber)
        {
            return _stockEntryRepository.Query()
            .Where(s => string.Equals(s.NfNumber,nfNumber,StringComparison.OrdinalIgnoreCase))
            .FirstOrDefault();
        }
        ///<summary>
        /// Gets the diff between the given drugs and the actual drugs
        ///</summary>  
        // ///<returns><
        public virtual IEnumerable<Drug> GetItemsWithPriceChanged(IEnumerable<Drug> drugs)
        {                        
            var drugsDict = drugs.ToDictionary(d => d.Ncm);            
            var existingDrugs = _drugService.GetDrugsByNcm(drugs.Select(d => d.Ncm));
            return existingDrugs.Where(d => drugs.Any(dd => dd.Ncm == d.Ncm && dd.DrugCost != d.DrugCost));
        }        
    }
}
