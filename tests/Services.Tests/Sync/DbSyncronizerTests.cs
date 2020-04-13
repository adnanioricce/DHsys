using Application.Services;
using Core.Entities.LegacyScaffold;
using Core.Models.Dbf;
using Core.Models.Resources.Requests;
using DAL;
using System.Collections.Generic;
using Tests.Lib.Data;
using Xunit;

namespace Services.Tests.Sync
{
    public class DbSyncronizerTests
    {
        [Fact]
        public void GenerateSyncScript_ReceivesRequestWithTableNameEqualAGENDAAnd1RecordDiffWithIsNewEqualToFalse_ShouldReturnSqlScriptWithUpdateQueryOnlyForChangedColumns()
        {
            //Given
            var request = new SyncDatabaseRequest
            {
                TableName = "AGENDA"
            };
            request.RecordDiffs.Add(1, new RecordDiff
            {
                RecordIndex = 1,
                RecordValue = new Agenda
                {
                    Bairro = "nome bairro",
                    Cep = "123456789",
                    Cidade = "nome cidade",
                    Codigo = "123456",
                    Endereco = "nome endereço",
                    Fone = "3455643",
                    Nome = "um nome"
                },
                ColumsChanged = new List<RecordColumn>
                {
                    new RecordColumn
                    {
                        ColumnName = "BAIRRO",
                        Value = "nome"
                    },
                    new RecordColumn
                    {
                        ColumnName = "CEP",
                        Value = "123456789"
                    }
                }
            });
            string expectedScript = "UPDATE AGENDA SET BAIRRO='nome bairro',CEP='123456789' WHERE Id = 1;";            
            var dbSyncronizer = new DbSynchronizer(null);
            //When
            string syncScript = dbSyncronizer.GenerateSyncScript(request);
            //Then
            Assert.Equal(expectedScript, syncScript);
        }
    }
}
