using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
using Core.Interfaces;
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
        public void CreateDrug(Drug drug)
        {
            //TODO:write Drug validation
            _drugRepository.Add(drug);
            _drugRepository.SaveChanges();
        }

        public void CreateDrug(Produto produto)
        {
            throw new System.NotImplementedException();
        }

        public void CreateDrugs(IEnumerable<Produto> produtos)
        {
            throw new System.NotImplementedException();
        }

        public void CreateDrugs(IEnumerable<Drug> drugs)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Drug> GetDrugs(int start, int end)
        {
            return _drugRepository.Query().TakeWhile(d => d.Id >= start && d.Id <= end);
        }

        public Task<IEnumerable<Drug>> GetDrugsAsync(int start, int end)
        {
            throw new System.NotImplementedException();
        }

        public Drug SearchDrugByBarCode(string barCode)
        {
            return _drugRepository.GetBy(barCode);
        }

        public Task<Drug> SearchDrugByBarCodeAsync(string barCode)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Drug> SearchDrugsByName(string name)
        {
            return _drugRepository.Query().Where(d => d.DrugName.Contains(name));
        }

        public Task<Drug> SearchDrugsByNameAsync(string name)
        {
            throw new System.NotImplementedException();
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
