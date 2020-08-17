using AspNetCore.Http.Extensions;
using Core.Entities.Financial;
using Core.Models.ApplicationResources;
using System.Net.Http;
using System.Threading.Tasks;
using Tests.Lib;
using Xunit;

namespace Api.Tests.Api
{
    public class BillingControllerTests : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;
        public BillingControllerTests(TestFixture<Startup> fixture)
        {

        }
        [Fact]
        public async Task GET_Read_ReceivesIntegerId_ExpectedToReturnEntityWithReceivedId()
        {
            // Arrange
            var baseUrl = "api/Billing/read/id={0}";
            var id = 1;
            string requestUrl = string.Format(baseUrl, id);
            // Act
            var result = await _client.GetAsync(requestUrl);
            var valueResult = await result.Content.ReadAsJsonAsync<BaseResourceResponse<Billing>>();
            // Assert
            Assert.True(valueResult.Success);
            Assert.Equal(1, valueResult.ResultObject.Id);
        }
        //TODO:POST,PUT and DELETE
    }
}
