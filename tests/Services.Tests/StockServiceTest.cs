using Xunit;
using UI.Entities.Stock;
using Tests.Lib.Data;
using System.Collections.Generic;
using System.Linq;
using UI.Services;

namespace Services.Tests
{
    public class StockServiceTest
    {
        [Fact]
        public void AddMultipleStockEntries_ReceivesCollectionWithValidStockEntries_ShouldWriteEachOneOnContext()
        {
            //Given
            var stocks = GetBaseStockEntries();
            var repo = new FakeRepository<Stockentries>();
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
            var invalidStocks = new List<Stockentries>{
                new Stockentries{

                },new Stockentries{

                }
            };
            stocks.Concat(invalidStocks);
            var repo = new FakeRepository<Stockentries>();
            var service = new StockService(repo);
            //When
            service.AddMultipleStockEntries(stocks);
            //Then
            var validEntries = repo.GetAll();
            Assert.Equal(2,validEntries.Count());
        }                        
        private IEnumerable<Stockentries> GetBaseStockEntries()
        {
            return new List<Stockentries>{
                new Stockentries{

                },
                new Stockentries{

                }
            };
        }
    }
}