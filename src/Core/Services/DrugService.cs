using Core.Entities.Catalog;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core.Services
{
    public class DrugService : IDrugService
    {
        private readonly IRepository<Drug> _drugRepository;
        public DrugService(IRepository<Drug> drugRepository)
        {
            _drugRepository = drugRepository;
        }
        public void CreateDrug(Drug product)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Drug> GetDrugs(int start, int end)
        {
            throw new System.NotImplementedException();
        }

        public Drug SearchDrugByBarCode(string barCode)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Drug> SearchDrugsByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateDrugPrice(int drugId, Drugprices newDrugPrice)
        {
            throw new System.NotImplementedException();
        }
    }
}
