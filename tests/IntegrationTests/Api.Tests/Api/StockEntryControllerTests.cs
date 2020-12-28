using AspNetCore.Http.Extensions;
using Core.ApplicationModels.Dtos.Stock;
using Core.Entities.Catalog;
using Core.Entities.Media;
using Core.Entities.Stock;
using Core.Interfaces;
using DAL.Seed;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests
{
    public class StockEntryControllerTests : ControllerTestBase<StockEntry,StockEntryDto>
    {
        public StockEntryControllerTests(ApiTestFixture fixture) : base(fixture) { }
        public override async Task POST_Create_ReceivesEntityObject_ExpectedToReturnCreatedEntity()
        {
            // Arrange
            var stockEntrySeed = _seeder.GetSeedObject();
            var drugSeed = new ProductSeed().GetSeedObject();            
            var url = GetRequestUrl("api/{0}/create?api-version=1.0", "POST");
            stockEntrySeed.AddEntry(drugSeed, DateTime.UtcNow.AddDays(-365), 4, Guid.NewGuid().ToString());
            // Act 
            var response = await _client.PostAsJsonAsync(url, stockEntrySeed);
            var content = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.True(response.IsSuccessStatusCode,content);
        }
    }
}