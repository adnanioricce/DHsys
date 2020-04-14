using Core.Entities.Catalog;
using Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services
{
    public class DrugService : IDrugService
    {
        private readonly IRepository<Drug> _drugRepository;
        public DrugService(IRepository<Drug> drugRepository)
        {
            _drugRepository = drugRepository;
        }
        public void CreateDrug(Drug drug)
        {
            //TODO:write Drug validation
            _drugRepository.Add(drug);
            _drugRepository.SaveChanges();
        }

        public IEnumerable<Drug> GetDrugs(int start, int end)
        {
            return _drugRepository.Query().TakeWhile(d => d.Id >= start && d.Id <= end);
        }

        public Drug SearchDrugByBarCode(string barCode)
        {
            return _drugRepository.GetBy(barCode);
        }

        public IEnumerable<Drug> SearchDrugsByName(string name)
        {
            return _drugRepository.Query().Where(d => d.DrugName.Contains(name));
        }

        public void UpdateDrugPrice(int drugId, DrugPrice newDrugPrice)
        {
            //TODO:Validate drug price
            var drug = _drugRepository.GetBy(drugId);
            drug.Drugprices.Add(newDrugPrice);
            _drugRepository.Update(drug);
        }
    }
}
