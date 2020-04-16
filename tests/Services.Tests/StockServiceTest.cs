using Xunit;
using Tests.Lib.Data;
using System.Collections.Generic;
using System.Linq;
using Core.Entities.Stock;
using Application.Services;

namespace Services.Tests
{
    public class StockServiceTest
    {
        [Fact]
        public void AddMultipleStockEntries_ReceivesCollectionWithValidStockEntries_ShouldWriteEachOneOnContext()
        {
            //Given
            var stocks = GetBaseStockEntries();
            var repo = new FakeRepository<StockEntry>();
            var service = new StockService(repo);
            //When
            service.AddMultipleStockEntries(stocks);
            //Then
            var entries = repo.GetAll();
            Assert.Equal(2,entries.Count());
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
            Assert.Equal(2,validEntries.Count());
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