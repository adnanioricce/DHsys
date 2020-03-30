using System.Collections.Generic;
using Core.Entities.Catalog;

namespace Core.Interfaces
{
    public interface IDrugService
    {
        IEnumerable<Drug> GetDrugs(int start,int end);
        void CreateDrug(Drug product);
        void UpdateDrugPrice(int drugId,Drugprices newDrugPrice);        
        
    }
}