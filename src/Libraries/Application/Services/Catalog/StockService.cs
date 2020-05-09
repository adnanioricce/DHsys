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

        public void AddMultipleStockEntries(IEnumerable<StockEntry> stockentries)
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
        public void AddStockEntry(StockEntry stockentry)
        {
            //TODO:Add Validation
            _stockEntryRepository.Add(stockentry);
        }
        public StockEntry GetByNfCode(string nfNumber)
        {
            return _stockEntryRepository.Query()
            .Where(s => string.Equals(s.NfNumber,nfNumber,StringComparison.OrdinalIgnoreCase))
            .FirstOrDefault();
        }
        ///<summary>
        /// Gets the diff between the given drugs and the actual drugs
        ///</summary>  
        // ///<returns><
        public IEnumerable<DrugDiff> GetDiff(IEnumerable<Drug> drugs)
        {
            var diffs = new List<DrugDiff>();
            //Move boths to dictionaries to access more easily
            var drugsDict = drugs.ToDictionary(d => d.Ncm);
            //getting drugs that alreadly exists on database
            var existingDrugs = _drugService.GetDrugsByNcm(drugs.Select(d => d.Ncm));
            var existingDrugsDict = existingDrugs.ToDictionary(d => d.Ncm);                                                
            //from getting the key and value of the given drugs
            foreach (var (ncm,drug) in drugsDict)
            {
                //if drug don't exists, continue, if not...
                if(!existingDrugsDict.TryGetValue(ncm,out var value)) continue;
                // try to compare properties of both
                var oldDrugProperties = drug.GetType()
                                                .GetProperties()
                                                // .Where(p => !p.PropertyType.IsClass)
                                                .Select(p => new {Name = p.Name,Value = p.GetValue(drug) })
                                                .ToDictionary(p => p.Name);
                    var changedProperties = value.GetType()
                    .GetProperties()
                    // .Where(p => !p.PropertyType.IsClass)
                    .Where(p => oldDrugProperties[p.Name] != p.GetValue(value))
                    .Select(p => new PropertyDiff{
                        PropertyName = p.Name,
                        Value = p.GetValue(value)
                    });
                    //if not has changed continue
                    if(changedProperties.Count() == 0) continue;
                    //if has changed, add to list
                    var diff = new DrugDiff{
                            PreviousDrug = drug,
                            CurrentDrug = value,
                            ChangedProperties = changedProperties.ToDictionary(p => p.PropertyName)                        
                        };     
                    diffs.Add(diff);                 
            }
            return diffs;
        }        
    }
}
