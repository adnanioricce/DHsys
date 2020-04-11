using Api.ApiModels;
using AspNetCore.Http.Extensions;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Api.IntegrationTests.Api
{
    public class SyncControllerTest : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient _client;
        public SyncControllerTest(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }
        [Fact]
        public async Task POST_SyncDatabase_ReceivesObjectWithRecordInfoAndValues_ShouldReturn200StatusResponseIfSyncWasSuccessful()
        {
            // Given
            var request = "/api/v1/sync/sync_dbf";
            var data = new SyncDatabaseRequest
            {
                FileName = "AGENDA.DBF"                
            };
            data.RecordDiffs.Add(1, new RecordDiff
            {
                Column = "ENDERECO",
                IsNew = false,
                RecordIndex = 1,
                Value = new
                {
                    Property = 1,
                    OtherProperty = 2
                }
            });
            // When
            var response = await _client.PostAsJsonAsync(request,data);

            // Then
            var message = response.EnsureSuccessStatusCode();
            Assert.Equal(200,(int)message.StatusCode);            
        }
    }
}
