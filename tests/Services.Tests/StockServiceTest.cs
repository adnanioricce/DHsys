using Xunit;
using Core.Entities.Stock;
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
            var result = service.AddMultipleStockEntries(stocks);
            //Then
            var entries = repo.GetAll();
            Assert.True();
        }   
        [Fact]
        public void AddMultipleStockEntries_ReceivesCollectionWithInvalidStockEntries_ShouldWriteOnlyValidEntriesOnContext()
        {
            //Given
            var stocks = GetBaseStockEntries();
            //TODO:Add invalid state
            var invalidStocks = new IEnumerable<Stockentries>{
                new Stockentries{

                },new Stockentries{

                }
            };
            stocks.Concat(invalidStocks);
            var repo = new FakeRepository<Stockentries>();
            var service = new StockService(repo);
            //When
            var result = service.AddMultipleStockEntries(stocks);
            //Then
            var validEntries = repo.GetAll();
            Assert.Equal(2,validEntries.Count());
        }                        
        private IEnumerable<Stockentries> GetBaseStockEntries()
        {
            return new IEnumerable<Stockentries>{
                new Stockentries{

                },
                new Stockentries{

                }
            };
        }
    }
}