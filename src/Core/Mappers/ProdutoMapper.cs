//The project is tied to a old legacy system, with it's own entities, and them will need to be mapped
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
using Core.Entities.Stock;
using Core.Interfaces;
using LibGit2Sharp;
//TODO: Move this to DAL project
namespace Core.Mappers
{
    public class ProdutoMapper : ILegacyDataMapper<Drug,Produto>
    {
        private readonly ILegacyRepository<Produto> _legacyProdutoRepository;
        private readonly IRepository<Produto> _produtoRepository;
        private readonly IRepository<Drug> _drugRepository;
        public ProdutoMapper(IRepository<Produto> produtoRepository,
            ILegacyRepository<Produto> legacyProdutoRepository,
            IRepository<Drug> drugRepository)
        {
            _legacyProdutoRepository = legacyProdutoRepository;
            _produtoRepository = produtoRepository;
            _drugRepository = drugRepository;
        }        
        public void SaveLegacyModelOnDatabase(string tableName)
        {
            var produtos = _legacyProdutoRepository.MultipleFromRawSqlQuery($"SELECT * FROM {tableName}");
            _produtoRepository.AddRange(produtos);
            _produtoRepository.SaveChanges();
        }
        
        public IEnumerable<Drug> MapTable(string tableName)
        {
            var produtoTable = _legacyProdutoRepository.QueryableByRawQuery($"SELECT * FROM {tableName}");
            var products = produtoTable.Select(p => MapToDomainModel(p));
            return products;
        }
        private Drug MapSimpleFields(Produto produto)
        {
            var drug = new Drug();
            drug.BarCode = produto.Prbarra;
            drug.UniqueCode = produto.Prcodi;
            drug.Description = produto.Prdesc;
            drug.LotNumber = produto.Prlote;
            drug.Ncm = produto.Prncms;
            drug.DrugName = produto.Prdesc;
            drug.DrugCost = decimal.TryParse(produto.Prfabr.ToString(), out var result) ? result : Convert.ToDecimal(produto.Prfabr);
            drug.Classification = produto.Prclas;
            drug.CommercialName = produto.Pretiq;
            drug.QuantityInStock = int.TryParse(produto.Prestq.ToString(), out var estResult) ? estResult : Convert.ToInt32(produto.Prestq);
            drug.PrCdse = produto.Prcdse;
            drug.ActivePrinciple = produto.Prprinci;
            drug.Section = produto.Secao;
            drug.EndCustomerPrice = Convert.ToDecimal(produto.Prcons);
            drug.DiscountValue = decimal.TryParse((produto.Prcons - (produto.Prcons * (produto.DescMax / 100))).ToString(),out var discountValue) ? discountValue : 0.00m;
            drug.PrescriptionNeeded = !string.IsNullOrEmpty(produto.Prlote) ? true : false;
            drug.ManufacturerName = produto.Prnola;
            drug.MinimumStock = int.TryParse(produto.EstMinimo.ToString(),out var minStockResult) ? minStockResult : 1;
            drug.MainSupplierName = produto.Ultfor;
            drug.Drugprices.Add(new Drugprices
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
            string value = produto.Prdesc.Split(' ').Where(desc => regex.IsMatch(desc)).Where(desc => desc.Contains("G")).FirstOrDefault();
            if (!string.IsNullOrEmpty(value))
            {
                drug.Dosage = value;
                drug.AbsoluteDosageInMg = double.TryParse(string.Join("", value.Select(d => char.IsDigit(d))), out var dosageValue) ? dosageValue : -1;
            }
            return drug;
        }           

        public IEnumerable<Drug> GetChanges(string tableName)
        {
            //TODO:Write a service to get the changes on dbf tables 
            throw new System.NotImplementedException();
        }       
    }    
}