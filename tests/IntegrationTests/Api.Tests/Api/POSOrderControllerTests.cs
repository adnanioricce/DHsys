using Api.Tests.Seed;
using AspNetCore.Http.Extensions;
using Core.ApplicationModels.Dtos.Financial;
using Core.Entities.Catalog;
using Core.Entities.Financial;
using Core.Models.ApplicationResources;
using DAL.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Tests.Lib;
using Xunit;

namespace Api.Tests
{
    public class POSOrderControllerTests : ControllerTestBase<POSOrder,POSOrderDto>
    {        
        public POSOrderControllerTests(ApiTestFixture fixture) : base(fixture)
        {            
        }
        [Fact]
        public async Task Given_POST_legacy_creates_CreateLegacys_When_requests_prcodi_and_quantity_Then_expects_200_status_code()
        {
            // Given
            var baseUrl = "api/POSOrder/create?api-version=1.0";
            var drug = new ProductSeed().GetSeedObject();
            var context = _fixture.GetContext();
            context.Add(drug);
            context.SaveChanges();
            var transaction = new POSOrderDto
            {
                HasDealWithStore = false,
                PaymentMethod = Core.Entities.Financial.PaymentMethods.InHands,                
                ConsumerCode = Guid.NewGuid().ToString(),
                Items = new POSOrderItemDto[]
                {
                    new POSOrderItemDto
                    {
                        ProductUniqueCode = drug.UniqueCode,                        
                        CostPrice = drug.CostPrice,
                        CustomerValue = drug.EndCustomerPrice,
                        Quantity = 1,
                    }
                }
            };
            // When
            //var result = _client.get
            var result = await _client.PostAsJsonAsync(baseUrl,transaction);
            var valueResult = await result.Content.ReadAsJsonAsync<BaseResourceResponse<POSOrderDto>>();
            // Then            
            Assert.True(valueResult.Success);            
        }
    }
}
