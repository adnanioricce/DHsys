using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;

namespace Core.Interfaces
{
    public interface IDrugService
    {
        IEnumerable<Drug> GetDrugs(int start,int end);
        Task<IEnumerable<Drug>> GetDrugsAsync(int start,int end);
        //Task<IEnumerable<Drug>> GetDrugsFrom
        Drug SearchDrugByBarCode(string barCode);
        Task<Drug> SearchDrugByBarCodeAsync(string barCode);
        Drug GetDrugByUniqueCode(string uniqueCode);        
        Task<Drug> GetDrugByUniqueCodeAsync(string uniqueCode);        
        IEnumerable<Drug> GetDrugsByNcm(IEnumerable<string> ncms);
        IEnumerable<Drug> SearchDrugsByName(string name);
        Task<Drug> SearchDrugsByNameAsync(string name);
        void CreateDrug(Drug product);
        void CreateDrug(Produto produto);
        void CreateDrugs(IEnumerable<Produto> produtos);
        void CreateDrugs(IEnumerable<Drug> drugs);
        void UpdateDrugPrice(int drugId,ProductPrice newDrugPrice);        
        
    }
}