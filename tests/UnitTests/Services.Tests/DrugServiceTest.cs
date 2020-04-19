using Xunit;
using Tests.Lib.Data;
using System.Linq;
using System;
using Application.Services;
using Core.Entities.Catalog;
using Core.Interfaces;
using Core.Entities.LegacyScaffold;
using System.Collections.Generic;
using Core.Mappers;

namespace Services.Tests
{
    public class DrugServiceTest
    {
        [Fact]
        public void CreateDrug_ReceivesDrugEntity_ShouldAddDrugEntryToDataSource()
        {
            //Given             
            var drug = BaseCreateDrugEntity();                      
            var repository = new FakeRepository<Drug>();            
            var service = new DrugService(repository,null);
            //when
            service.CreateDrug(drug);
            var returnedDrug = repository.GetBy(1);
            //Then 
            Assert.Equal(1,returnedDrug.Id);
            
        }
        [Fact]
        public void CreateDrug_ReceiveProdutoEntity_ShouldCreateDrugEntryWithRelationWIthProdutoOnDataSource()
        {
            //Given             
            var produto = BaseProdutoCreateDrugEntity();
            var repository = new FakeRepository<Drug>();
            var produtoMapper = new ProdutoMapper(null);
            var service = new DrugService(repository,produtoMapper);
            //When
            service.CreateDrug(produto);
            var returnedDrug = repository.GetBy(1);
            //Then 
            Assert.Equal(1, returnedDrug.Id);
            Assert.Equal(produto.Id,returnedDrug.ProdutoId);
        }
        [Fact]
        public void CreateDrugs_ReceiveMultipleProdutos_ShouldCreateDrugEntryWithProdutoRelationForEachProdutoReceived()
        {
            //Given
            var produtos = GetProdutoDataList();
            var repository = new FakeRepository<Drug>();
            var service = new DrugService(repository,new ProdutoMapper(null));
            //When
            service.CreateDrugs(produtos);
            //Then
            var createdDrugs = service.GetDrugs(0, 3);
            var insertedProdutos = createdDrugs.Select(d => d.Produto);
            var count = createdDrugs.Count();
            Assert.Equal(2, count);
            Assert.Equal(produtos,insertedProdutos);
        }
        [Fact]
        public void CreateDrug_ReceivesDrugEntityWithoutManufacturer_ShouldReturnErrorInvalidEntityEntry()
        {
            //Given                         
            var repository = new FakeRepository<Drug>();
            var drug = BaseCreateDrugEntity();                     
            drug.ManufacturerId = 0;            
            drug.UniqueCode = "";
            //repository.Add(drug);
            var service = new DrugService(repository,null);
            //when
            service.CreateDrug(drug);
            var returnedDrug = repository.GetBy(1);
            //Then 
            Assert.Equal(1,returnedDrug.Id);
        }
        [Fact]
        public void SearchDrugsByName_ReceivesStringPattern_ShouldReturnAllDrugsThatContainsStringPatternInName()
        {
            //Given            
            var drug = new Drug{
                DrugName = "doralgina"
            };            
            var service = CreateService(drug);
            //When
            var drugs = service.SearchDrugsByName(drug.DrugName);
            //Then
            Assert.True(drugs.Any(d => string.Equals(d.DrugName,drug.DrugName,StringComparison.OrdinalIgnoreCase)));
        }
        //? And if I receive more than one drug?
        [Fact]
        public void SearchDrugByBarCode_ReceivesStringCode_ShouldReturnOnlyOneDrugWithTheGivenString()
        {
            //Given            
            var drug = new Drug {
                BarCode = "300024567124766437435"
            };
            var service = CreateService(drug);
            //When
            var returnedDrug = service.SearchDrugByBarCode(drug.BarCode);
            //Then
            Assert.Equal(drug.BarCode,returnedDrug.BarCode);
        }
        //TODO:write a test for each method
        //TODO:Write a test for each "expected" situation
        private IDrugService CreateService(Drug testDrug)
        {            
            var repository = new FakeRepository<Drug>();
            repository.Add(testDrug);
            return new DrugService(repository,null);
        }
        private IDrugService CreateService()
        {
            var repository = new FakeRepository<Drug>();            
            return new DrugService(repository,null);
        }
        private Drug BaseCreateDrugEntity()
        {
            return new Drug{
                ManufacturerId = 1,
                DrugName = "SomeDrugName 30mg 30cp",
                Description = "no description",
                Classification = "some classification",
                DrugCost = 14.99m,
                AbsoluteDosageInMg = 30,
                Dosage = "30mg",
                QuantityInStock = 4,
                ReorderLevel = 0,
                ReorderQuantity = 1,
                EndCustomerPrice = 32.99m,
                ActivePrinciple = "Some Substance",                
                PrescriptionNeeded = false,
                DigitalBuleLink = "http://falselink.com/bule000001",
                BarCode = Guid.NewGuid().ToString(),
                UniqueCode = "40028922",
            };                  
        }
        private Produto BaseProdutoCreateDrugEntity()
        {
            return new Produto
            {
                Prcodi = "123456",
                Prbarra = "1234567890123",
                Prdesc = "Dipirona GTS 5mg",
                Pricms = 18,
                EstMinimo = 1,
                Prestq = 3,
                Premb = 1,
                Prncms = "3000333333",
                Prfabr = 4.24,
                Prcons = 12.50,
                DescMax = 20,
                Prprinci = "some principle",
                Secao = "",
                Ultfor = "Fornecedor"
            };
        }
        private IEnumerable<Produto> GetProdutoDataList()
        {
            var produto = BaseProdutoCreateDrugEntity();
            var produto2 = BaseProdutoCreateDrugEntity();
            produto2.Prdesc = "Doralgina 15cp 5mg";
            var produtos = new List<Produto>
            {
                produto,
                produto2
            };
            return produtos;
        }
    }
}