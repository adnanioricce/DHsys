using AspNetCore.Http.Extensions;
using System.Net.Http;
using System.Threading.Tasks;
using Tests.Lib;
using Xunit;

namespace Api.Tests.Api
{
    public class DefaultApiControllerTests : IClassFixture<TestFixture<Startup>>
    {
        protected readonly TestFixture<Startup> _fixture;
        protected readonly HttpClient _client;
        public DefaultApiControllerTests(TestFixture<Startup> fixture)
        {
            _fixture = fixture;
            _client = _fixture.Client;
            
        }

        public async Task TestAll()
        {
            var response = await _client.GetAsync("swagger/1.0/swagger.json");
            var apiDefinition = await response.Content.ReadAsJsonAsync<dynamic>();
            foreach(var path in apiDefinition.paths)
            {
                //TODO:search for the basic get,post,put,delete,validate-create and query endpoints in DefaultApiController
            }
        }
    }
}
