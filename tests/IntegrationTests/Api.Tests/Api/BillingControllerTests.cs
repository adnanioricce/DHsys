using AspNetCore.Http.Extensions;
using Core.ApplicationModels.Dtos.Financial;
using Core.Entities.Financial;
using Core.Models.ApplicationResources;
using DAL.DbContexts;
using DAL.Extensions;
using System;
using System.Threading.Tasks;
using Tests.Lib;
using Xunit;

namespace Api.Tests
{
    public class BillingControllerTests : IClassFixture<TestFixture<Startup>>
    {        
        private readonly TestFixture<Startup> _fixture;
        public BillingControllerTests(TestFixture<Startup> fixture)
        {
            _fixture = fixture;
        }
        [Fact]
        public async Task GET_Read_ReceivesIntegerId_ExpectedToReturnEntityWithReceivedId()
        {
            // Arrange
            var client = _fixture.Client;
            var baseUrl = "api/Billing/{0}";                        
            var billing = new Billing
            {
                BeneficiaryName = "FAKE Beneficiary",
                CreatedAt = DateTimeOffset.UtcNow,
                Discount = 0,
                PersonType = Core.Entities.PersonDocumentType.Cnpj,
                UniqueCode = Guid.NewGuid().ToString(),
                Price = 12.99m,
                EndDate = DateTime.Today.AddDays(TimeSpan.FromDays(3).TotalDays),
                IsPaid = false                
            };            
            var context = _fixture.GetRemoteContext();
            context.Add(billing);
            var changes = context.SaveChanges();
            string requestUrl = string.Format(baseUrl, billing?.Id);
            // Act
            var result = await client.GetAsync(requestUrl);
            var valueResult = await result.Content.ReadAsJsonAsync<BaseResourceResponse<BillingDto>>();
            // Assert
            Assert.True(valueResult.Success);
            Assert.Equal(billing?.Id, valueResult.ResultObject.Id);
        }
        [Fact]
        public async Task POST_Create_receives_entity_model_Expected_to_return_200_ok_object_with_entity_id_created()
        {
            // Arrange
            var client = _fixture.Client;
            var baseUrl = "api/Billing/create";
            var billing = new Billing
            {
                BeneficiaryName = "FAKE Beneficiary",
                CreatedAt = DateTimeOffset.UtcNow,
                Discount = 0,
                PersonType = Core.Entities.PersonDocumentType.Cnpj,
                UniqueCode = Guid.NewGuid().ToString(),
                Price = 12.99m,
                EndDate = DateTime.Today.AddDays(TimeSpan.FromDays(3).TotalDays),
                IsPaid = false,
            };
            // Act
            var response = await client.PostAsJsonAsync(baseUrl, billing);
            // Assert
            Assert.Equal(200, (int)response.StatusCode);
        }
        [Fact]
        public async Task PUT_Update_receives_id_and_entity_model_Expected_to_return_200_ok_object()
        {
            // Arrange
            var client = _fixture.Client;
            var baseUrl = "api/Billing/{0}";
            var billing = new Billing
            {
                BeneficiaryName = "FAKE Beneficiary",
                CreatedAt = DateTimeOffset.UtcNow,
                Discount = 0,
                PersonType = Core.Entities.PersonDocumentType.Cnpj,
                UniqueCode = Guid.NewGuid().ToString(),
                Price = 12.99m,
                EndDate = DateTime.Today.AddDays(TimeSpan.FromDays(3).TotalDays),
                IsPaid = false,
            };
            var context = _fixture.GetRemoteContext();
            context.Add(billing);
            context.SaveChanges();
            billing.EndDate = billing.EndDate.Value.AddDays(TimeSpan.FromDays(1).TotalDays);
            string requestUrl = string.Format(baseUrl, billing?.Id);
            // Act
            var response = await client.PutAsJsonAsync(requestUrl, billing);
            // Assert
            Assert.Equal(200, (int)response.StatusCode);
        }
        [Fact]
        public async Task DELETE_Delete_receives_id_Expected_to_return_200_ok_object_if_delete_is_successful()
        {
            // Arrange
            var client = _fixture.Client;
            var baseUrl = "api/Billing/{0}";
            var billing = new Billing
            {
                BeneficiaryName = "FAKE Beneficiary",
                CreatedAt = DateTimeOffset.UtcNow,
                Discount = 0,
                PersonType = Core.Entities.PersonDocumentType.Cnpj,
                UniqueCode = Guid.NewGuid().ToString(),
                Price = 12.99m,
                EndDate = DateTime.Today.AddDays(TimeSpan.FromDays(3).TotalDays),
                IsPaid = false,
            };
            var context = _fixture.GetRemoteContext();
            context.Add(billing);
            context.SaveChanges();            
            string requestUrl = string.Format(baseUrl, billing?.Id);
            // Act
            var response = await client.DeleteAsync(requestUrl);
            // Assert
            Assert.Equal(200, (int)response.StatusCode);
        }        
    }
}