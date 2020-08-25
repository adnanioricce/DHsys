using AspNetCore.Http.Extensions;
using Core.Entities.Catalog;
using Core.Models.ApplicationResources;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Tests.Lib;
using Xunit;

namespace Api.Tests
{
    public class TransactionsControllerTests : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;
        public TransactionsControllerTests(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }
        [Fact]
        public async Task Given_POST_legacy_creates_CreateLegacys_When_requests_prcodi_and_quantity_Then_expects_200_status_code()
        {            
            // Given
            var baseUrl = "api/Drugs/search/list?name={0}";
            string name = "Dipirona";
            string requestUrl = string.Format(baseUrl, name);
            // When
            //var result = _client.get
            var result = await _client.GetAsync(requestUrl);
            var valueResult = await result.Content.ReadAsJsonAsync<BaseResourceResponse<IEnumerable<Drug>>>();
            // Then
            var count = valueResult.ResultObject.Count();
            Assert.True(valueResult.Success);
            Assert.True(valueResult.ResultObject.Count() > 0);
        }
    }
}
