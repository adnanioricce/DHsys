using Xunit;
using Tests.Lib.Data;
using System.Collections.Generic;
using System.Linq;
using Core.Entities.Stock;
using Application.Services;
using Tests.Lib.Seed;
using Core.Entities.Catalog;
using Core.Interfaces;
using Moq;
using System;

namespace Services.Tests.Catalog
{
    public class StockServiceTest
    {
        [Fact]
        public void WhenAddingMultipleStockEntries_ExpectCollectionWithValidStockEntries_ThenWriteEachOneOnContext()
        {
            //Given
            var stocks = GetBaseStockEntries();
            var repo = new FakeRepository<StockEntry>();
            var service = new StockService(repo,null);
            //When
            service.AddMultipleStockEntries(stocks);
            //Then
            var entries = repo.GetAll();
            Assert.Equal(3,entries.Count());
        }   
        [Fact]
        public void AddMultipleStockEntries_ReceivesCollectionWithInvalidStockEntries_ShouldWriteOnlyValidEntriesOnContext()
        {
            //Given
            var stocks = GetBaseStockEntries();
            //TODO:Add invalid state StockEntry seed
            var invalidStocks = new List<StockEntry>{
                new StockEntry{

                },new StockEntry{

                }
            };
            stocks.Concat(invalidStocks);
            var repo = new FakeRepository<StockEntry>();
            var service = new StockService(repo,null);
            //When
            service.AddMultipleStockEntries(stocks);
            //Then
            var validEntries = repo.GetAll();
            Assert.Equal(3,validEntries.Count());
        }                     
        [Fact]
        public void Given_New_StockEntry_With_Drugs_With_DrugCostChanged_Between_Last_StockEntry_Of_Each_Product_When_Get_Diff_Between_Current_Products_And_StockEntry_Product_Then_Return_List_With_Previous_And_New_Product_Object()
        {
            //Given
            var oldProduct = ProductSeed.BaseCreateProductEntity();
            var newProduct = ProductSeed.BaseCreateProductEntity();
            oldProduct.Ncm = "300024567";
            newProduct.Ncm = oldProduct.Ncm;            
            newProduct.UpdatePrice(oldProduct.EndCustomerPrice + 1.0m, newProduct.CostPrice + 0.01m, DateTimeOffset.UtcNow);
            var service = new StockService(new FakeRepository<StockEntry>(),
            new ProductService(new FakeRepository<Product>(new Product[]{ oldProduct })));
            //When
            var result = service.GetItemsWithPriceChanged(new List<Product>{
                newProduct
            });
            //Then
            Assert.Single(result);            
        }              
        private IEnumerable<StockEntry> GetBaseStockEntries()
        {
            return new List<StockEntry>{
                new StockEntry{

                },
                new StockEntry{

                }
            };
        }
        private IProductService GetFakeDrugService(Product drug)
        {
            var fakeDrugService = new Mock<IProductService>();
            fakeDrugService.Setup(m => m.GetProductsByNcm(It.IsAny<string[]>()))
                           .Returns(new Product[]{
                                drug
                           });
            return fakeDrugService.Object; 
        }
    }
}