//The project is tied to a old legacy system, with it's own entities, and them will need to be mapped
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
using Core.Entities.Stock;
using Core.Interfaces;

namespace Core.Mappers
{
    public class ProdutoMapper : ILegacyDataMapper<Drug,Produto>
    {
        private readonly ILegacyRepository<Produto> _produtoRepository;
        private readonly IRepository<Drug> _drugRepository;
        public ProdutoMapper(ILegacyRepository<Produto> produtoRepository,IRepository<Drug> drugRepository)
        {
            _produtoRepository = produtoRepository;
            _drugRepository = drugRepository;
        }        
        public void SaveLegacyModelOnDatabase()
        {

        }
        
        public IEnumerable<Drug> MapTable(string tableName)
        {
            var produtoTable = _produtoRepository.QueryableByRawQuery($"SELECT * FROM {tableName}");
            var products = produtoTable.Select(p => MapToDomainModel(p));
            return products;
        }
        private Drug MapSimpleFields(Produto produto)
        {            
            var drug = new Drug
            {
                BarCode = produto.Prbarra,
                UniqueCode = produto.Prcodi,
                Description = produto.Prdesc,
                LotNumber = produto.Prlote,
                Ncm = produto.Prncms,
                DrugName = produto.Prdesc,
                DrugCost = decimal.TryParse(produto.Prfabr.ToString(), out var result) ? result : (decimal)produto.Prfabr,
                Classification = produto.Prclas,
                CommercialName = produto.Pretiq,
                QuantityInStock = int.TryParse(produto.Prestq.ToString(), out var estResult) ? estResult : (int)produto.Prestq,
                PrCdse = produto.Prcdse,
                ActivePrinciple = produto.Prprinci,
                Section = produto.Secao,
                EndCustomerPrice = (decimal)produto.Prfinal,
                DiscountValue = (decimal)(produto.Prfinal - (produto.Prfinal * (produto.DescMax / 100))),                
                PrescriptionNeeded = !string.IsNullOrEmpty(produto.Prlote) ? true : false,
                ManufacturerName = produto.Prnola,     
                MinimumStock = (int)produto.EstMinimo,   
                MainSupplierName = produto.Ultfor
                
            };
            //TODO:Wrap all this around another method
            
            string pattern = "\\d+[a-zA-z]";
            var regex = new Regex(pattern);
            string value = produto.Prdesc.Split(' ').Where(desc => regex.IsMatch(desc)).Where(desc => desc.Contains("G")).FirstOrDefault();
            if(value.Length > 1)
            {
                drug.Dosage = value;
                drug.AbsoluteDosageInMg = double.TryParse(string.Join("", value.Select(d => char.IsDigit(d))), out var dosageValue) ? dosageValue : -1;
            }            
            return drug;
        }
        public Drug MapToDomainModel(Produto produto)
        {
            //TODO:Not all fields are mapped
            var drug = MapSimpleFields(produto);
            drug.ShelfLifes.Add(new ProductShelfLife
            {
                EndDate = produto.Prvalid
            });
            drug.Produto = produto;
            drug.ProdutoId = produto.Id;
            return drug;
        }           

        public IEnumerable<Drug> GetChanges(string tableName)
        {
            //TODO:Write a service to get the changes on dbf tables 
            throw new System.NotImplementedException();
        }

        public void PersistChanges(IEnumerable<Drug> changedEntities)
        {
            _drugRepository.AddRange(changedEntities);
            _drugRepository.SaveChanges();
        }
    }    
}