//The project is tied to a old legacy system, with it's own entities, and them will need to be mapped
using System.Linq;
using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
using Core.Entities.Stock;
using Core.Interfaces;

namespace Core.Mappers
{
    public class ProdutoMapper : ILegacyDataMapper<Drug,Produto>
    {        
        private readonly IRepository<Supplier> _supplierRepository;
        public ProdutoMapper(IRepository<Supplier> supplierRepository)
        {            
            _supplierRepository = supplierRepository;
        }
        public Drug MapToDomainModel(Produto produto)
        {
            //TODO:Not all fields are mapped
            var supplier = _supplierRepository.Query()
                                              .Where(m => m.SupplierName.Contains(produto.Ultfor))
                                              .FirstOrDefault();
            var drug = new Drug{
                BarCode = produto.Prbarra,
                Code = produto.Prcodi,
                Description = produto.Prdesc,
                LotNumber = produto.Prlote,
                Ncm = produto.Prncms,
                DrugName = !string.IsNullOrEmpty(produto.Pretiq) ? produto.Pretiq : produto.Prdesc,
                DrugCost = decimal.TryParse(produto.Prfabr.ToString(),out var result) ? result : (decimal)produto.Prfabr,
                Classification = produto.Prclas,
                CommercialName = produto.Pretiq,
                QuantityInStock = int.TryParse(produto.Prestq.ToString(),out var estResult) ? estResult : (int)produto.Prestq,
                PrCdse = produto.Prcdse,                
                Substance = produto.Prprinci,
                Section = produto.Secao,
                Supplier = !(supplier is null) ? supplier : new Supplier{
                    SupplierName = produto.Ultfor,
                    
                },
            };  
            drug.ShelfLifes.Add(new ProductShelfLife{
                EndDate = produto.Prvalid
            });
            return drug;
        }   
    }    
}