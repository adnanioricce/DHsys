//The project is tied to a old legacy system, with it's own entities, and them will need to be mapped
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Core.Entities;
using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
using Core.Entities.Stock;
using Core.Interfaces;
using Core.Models;
using LibGit2Sharp;
//TODO: Move this to DAL project
namespace Core.Mappers
{
    public class ProdutoMapper : ILegacyDataMapper<Drug,Produto>
    {
        private readonly ILegacyRepository<Produto> _legacyProdutoRepository;        
        
        public ProdutoMapper(ILegacyRepository<Produto> legacyProdutoRepository)
        {
            _legacyProdutoRepository = legacyProdutoRepository;                    
        }                
        
        public IEnumerable<Drug> MapTable(string tableName)
        {
            var produtoTable = _legacyProdutoRepository.QueryableByRawQuery($"SELECT * FROM {tableName}");
            var products = produtoTable.Select(MapToDomainModel);
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
                DrugCost = decimal.TryParse(produto.Prfabr.ToString(), out var result) ? result : Convert.ToDecimal(produto.Prfabr),
                Classification = produto.Prclas,
                CommercialName = produto.Pretiq,
                QuantityInStock = int.TryParse(produto.Prestq.ToString(), out var estResult) ? estResult : Convert.ToInt32(produto.Prestq),
                PrCdse = produto.Prcdse,
                ActivePrinciple = produto.Prprinci,
                Section = produto.Secao,
                EndCustomerPrice = Convert.ToDecimal(produto.Prcons),
                DiscountValue = decimal.TryParse((produto.Prcons - (produto.Prcons * (produto.DescMax / 100))).ToString(), out var discountValue) ? discountValue : 0.00m,
                PrescriptionNeeded = !string.IsNullOrEmpty(produto.Prlote),
                ManufacturerName = produto.Prnola,
                MinimumStock = int.TryParse(produto.EstMinimo.ToString(), out var minStockResult) ? minStockResult : 1,
                MainSupplierName = produto.Ultfor
            };
            drug.Drugprices.Add(new DrugPrice
            {
                Drug = drug,
                EndCustomerDrugPrice = decimal.TryParse(produto.Prcons.ToString(),out var price) ? price : 0.00m,
                CostPrice = decimal.TryParse(produto.Prfabr.ToString(),out var fabrPrice) ? fabrPrice : 0.00m,
                Pricestartdate = DateTime.UtcNow

            });            
            //};
            //TODO:Wrap all this around another method
            
                    
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
            string pattern = "\\d+[a-zA-z]";
            var regex = new Regex(pattern);
            if (string.IsNullOrEmpty(produto.Prdesc))
            {
                return drug;
            }
            string value = produto.Prdesc.Split(' ')
                .Where(desc => regex.IsMatch(desc))
                .Where(desc => desc.Contains("G"))
                .FirstOrDefault();
            if (!string.IsNullOrEmpty(value))
            {
                drug.Dosage = value;
                drug.AbsoluteDosageInMg = double.TryParse(string.Join("", value.Select(d => char.IsDigit(d))), out var dosageValue) ? dosageValue : -1;
            }
            return drug;
        }

        public TableChanges<Drug> GetChanges(string tableName)
        {
            throw new NotImplementedException();
        }
        //?Actually, this should not happen here

    }    
}