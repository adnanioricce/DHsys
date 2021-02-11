using Core.Entities.Stock;
using DAL.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Lib;
using Xunit;

namespace DAL.Tests.Repository
{
    public class StockEntryTests : BaseRepositoryTest<StockEntry>
    {
        [Fact(DisplayName = "If already inserted, should relate Product when add new product stock entry ")]
        public virtual async Task AddProductStockEntryWithAfterCreation()
        {
            // Arrange
            var stockEntry = _seeder.GetSeedObject();
            var product = new ProductSeed().GetSeedObject();            
            _context.AddRange(stockEntry,product);
            _context.SaveChanges();
            // Act
            var lotCode = String.Format("LOT23CO4E-{0}", Guid.NewGuid().ToString());
            stockEntry.AddEntry(product, null, 1, lotCode);
            _repository.Update(stockEntry);
            var result = await _repository.SaveChangesAsync();
            // Then
            var stockEntryOnProduct = product.Stockentries.Where(p => p.StockEntryId == stockEntry.Id).FirstOrDefault();
            Assert.Equal(stockEntryOnProduct.StockEntryId, stockEntry.Id);
        }
    }
}
