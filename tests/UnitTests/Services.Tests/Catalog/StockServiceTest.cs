using Xunit;
using Tests.Lib.Data;
using System.Collections.Generic;
using System.Linq;
using Core.Entities.Stock;
using Application.Services;

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
            var service = new StockService(repo);
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
            //TODO:Add invalid state
            var invalidStocks = new List<StockEntry>{
                new StockEntry{

                },new StockEntry{

                }
            };
            stocks.Concat(invalidStocks);
            var repo = new FakeRepository<StockEntry>();
            var service = new StockService(repo);
            //When
            service.AddMultipleStockEntries(stocks);
            //Then
            var validEntries = repo.GetAll();
            Assert.Equal(3,validEntries.Count());
        }     
        //TODO:     
        [Fact]
        public void Given_New_StockEntry_With_Differences_Between_Last_StockEntry_Of_Each_Product_When_Get_Diff_Between_Current_Products_And_StockEntry_Product_Then_Return_List_With_Previous_And_New_Product_Object()
        {
            //Given
             
            //When
            
            //Then
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
    }
}