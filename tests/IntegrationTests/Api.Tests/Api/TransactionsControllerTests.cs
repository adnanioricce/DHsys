using Api.Tests.Seed;
using AspNetCore.Http.Extensions;
using Core.ApplicationModels.Dtos.Financial;
using Core.Entities.Catalog;
using Core.Entities.Financial;
using Core.Models.ApplicationResources;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Tests.Lib;
using Xunit;

namespace Api.Tests
{
    public class TransactionsControllerTests : ControllerTestBase<Transaction,TransactionDto,Startup>
    {        
        public TransactionsControllerTests(TestFixture<Startup> fixture) : base(fixture)
        {            
        }
        [Fact]
        public async Task Given_POST_legacy_creates_CreateLegacys_When_requests_prcodi_and_quantity_Then_expects_200_status_code()
        {
            // Given
            var baseUrl = "api/Transactions/create?api-version=1.0";
            var drug = DrugSeed.GetDrugForTransactions().FirstOrDefault();
            var context = _fixture.GetRemoteContext();
            context.Add(drug);
            context.SaveChanges();
            var transaction = new TransactionDto
            {
                HasDealWithStore = false,
                PaymentMethod = Core.Entities.Financial.PaymentMethods.InHands,                
                Items = new TransactionItemDto[]
                {
                    new TransactionItemDto
                    {
                        DrugUniqueCode = drug.UniqueCode,
                        CostPrice = drug.CostPrice,
                        CustomerValue = drug.EndCustomerPrice.Value,
                        Quantity = 1,
                    }
                }
            };
            // When
            //var result = _client.get
            var result = await _client.PostAsJsonAsync(baseUrl,transaction);
            var valueResult = await result.Content.ReadAsJsonAsync<BaseResourceResponse<TransactionDto>>();
            // Then            
            Assert.True(valueResult.Success);            
        }
    }
}
