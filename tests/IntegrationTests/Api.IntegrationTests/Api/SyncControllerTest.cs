using AspNetCore.Http.Extensions;
using Core.Entities.LegacyScaffold;
using Core.Models.Dbf;
using Core.Models.Resources.Requests;
using System;
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
        public async Task POST_SyncDatabase_ReceivesObjectWithNewRecordInfoAndValues_ShouldReturn200StatusResponseIfSyncWasSuccessful()
        {
            // Given
            var request = "/api/v1/sync/sync_dbf";
            var data = new SyncDatabaseRequest
            {
                TableName = "AGENDA.DBF"                
            };
            data.RecordDiffs.Add(1, new RecordDiff
            {                
                IsNew = true,
                RecordIndex = 1,
                ColumsChanged = null,
                RecordValue = new Agenda
                {
                    Bairro = "bairro",
                    Cep = "123456789",
                    Cidade = "cidade",
                    Codigo = "codigo",
                    Endereco = "endereço",
                    Nome = "nome",
                    Fone = "fone",                    
                }
                
            });
            data.RecordDiffs.Add(2, new RecordDiff
            {
                IsNew = false,
                RecordIndex = 2,
                RecordValue = new Agenda
                {
                    Bairro = "Nome Bairro",
                    Cep = "123456789",
                },
                ColumsChanged = new List<RecordColumn>
                {
                    new RecordColumn
                    {
                        ColumnName = "Bairro",
                        Value = "Nome Bairro"
                    },
                    new RecordColumn
                    {
                        ColumnName = "Cep",
                        Value = "123456789"
                    }
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
