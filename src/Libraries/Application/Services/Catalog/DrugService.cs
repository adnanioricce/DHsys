using Core.Entities.Catalog;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DrugService : IDrugService
    {
        private readonly IRepository<Drug> _drugRepository;        
        public DrugService(IRepository<Drug> drugRepository)
        {
            _drugRepository = drugRepository;            
        }
        public virtual void CreateDrug(Drug drug)
        {
            //TODO:write Drug validation
            _drugRepository.Add(drug);
            _drugRepository.SaveChanges();
        }

        public Task CreateDrugAsync(Drug drug)
        {
            throw new NotImplementedException();
        }

        public virtual void CreateDrugs(IEnumerable<Drug> drugs)
        {                                    
            _drugRepository.AddRange(drugs);
            _drugRepository.SaveChanges();
        }

        public Task CreateDrugsAsync(IEnumerable<Drug> drugs)
        {
            throw new NotImplementedException();
        }

        public virtual Drug GetDrugByUniqueCode(string uniqueCode)
        {
            return _drugRepository.Query()
            .Where(d => d.UniqueCode == uniqueCode)
            .FirstOrDefault();
        }

        public virtual Task<Drug> GetDrugByUniqueCodeAsync(string uniqueCode)
        {
            return _drugRepository.Query()
            .Where(d => d.UniqueCode == uniqueCode)
            .FirstOrDefaultAsync();
        }

        public virtual IEnumerable<Drug> GetDrugs(int start, int end)
        {
            return _drugRepository.Query().TakeWhile(d => d.Id >= start && d.Id <= end);
        }

        public virtual async Task<IEnumerable<Drug>> GetDrugsAsync(int start, int end)
        {
            return await _drugRepository.Query()
                                        .Take(start - end)
                                        .ToListAsync();
        }

        public virtual IEnumerable<Drug> GetDrugsByNcm(IEnumerable<string> ncms)
        {
            return _drugRepository.Query()
            .Where(drug => ncms.Any(nc => nc == drug.Ncm));
        }

        public virtual Drug SearchDrugByBarCode(string barCode)
        {
            return _drugRepository
                .Query()
                .Where(d => d.BarCode == barCode)                
                .FirstOrDefault();
        }

        public virtual Task<Drug> SearchDrugByBarCodeAsync(string barCode)
        {
            return _drugRepository.Query()
                .Where(d => 
                EF.Functions.Like(d.BarCode.ToLower(), "%" + barCode.ToLower() + "%") 
                || EF.Functions.Like(d.UniqueCode, "%" + barCode.ToLower() + "%"))
                .FirstOrDefaultAsync();
        }

        public virtual IEnumerable<Drug> SearchDrugsByName(string name)
        {
            return _drugRepository.Query().Where(d => EF.Functions.Like(d.DrugName.ToLower(), "%" + name.ToLower() + "%") 
                || EF.Functions.Like(d.Description.ToLower(), "%" + name.ToLower() + "%"));
        }

        public virtual async Task<IEnumerable<Drug>> SearchDrugsByNameAsync(string name)
        {       
            return await _drugRepository.Query()
                                        .Where(d => d.DrugName.Contains(name))                                
                                        .ToListAsync();
        }

        public virtual void UpdateDrug(int drugId, Drug drug)
        {
            var _drug = _drugRepository.GetBy(drugId);
            if(_drug is null)
            {
                return;
            }
            _drugRepository.Update(drug);
        }

        public virtual void UpdateDrugPrice(int drugId, ProductPrice newDrugPrice)
        {
            //TODO:Validate drug price
            var drug = _drugRepository.GetBy(drugId);
            drug.ProductPrices.Add(newDrugPrice);
            _drugRepository.Update(drug);
        }
    }
}