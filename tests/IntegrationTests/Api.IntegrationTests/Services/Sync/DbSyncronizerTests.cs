using Application.Services;
using Core.Entities.LegacyScaffold;
using Core.Interfaces;
using Core.Models.Dbf;
using Core.Models.Resources.Requests;
using DAL;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace Api.IntegrationTests.Services.Sync
{
    public class DbSyncronizerTests : IDisposable
    {
        private readonly IDbConnection _connection;
        private readonly IDbSynchronizer _dbSyncronizer;
        public DbSyncronizerTests(IDbSynchronizer dbSyncronizer)
        {
            _connection = new SqliteConnection("Data Source=database.db");
            _dbSyncronizer = dbSyncronizer;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        [Fact]
        public void GenerateSyncScript_ReceivesRequestWithTableNameEqualAGENDAAnd1RecordDiffWithIsNewEqualToFalse_ShouldReturnSqlScriptWithUpdateQueryOnlyForChangedColumns()
        {
            //TODO: check if query actually is valid running it on context
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
                        Value = "nome bairro"
                    },
                    new RecordColumn
                    {
                        ColumnName = "CEP",
                        Value = "123456789"
                    }
                }
            });
            _connection.Open();
            var command = _connection.CreateCommand();
            var insertScript = $"INSERT INTO AGENDA(Bairro,Cep) VALUES({string.Join(',', request.RecordDiffs[1].ColumsChanged.Select(c => $"'{c.Value}'"))})";
            command.CommandText = insertScript;
            var insertResult = command.ExecuteNonQuery();
            _connection.Close();
            //When
            var syncScript = _dbSyncronizer.GenerateSyncScript(request);
            _connection.Open();
            command.CommandText = syncScript;
            int syncResult = command.ExecuteNonQuery();
            var query = "SELECT * FROM Agenda WHERE Id = 1";
            command.CommandText = query;
            var reader = command.ExecuteReader();
            var expectedAgenda = request.RecordDiffs[1].RecordValue as Agenda;
            var agenda = new Agenda();                     
            while (reader.Read())
            {
                //for (int i = 0; i < reader.FieldCount; ++i)
                //{
                //if (count == 0)
                //{                
                agenda.Bairro = reader["Bairro"].ToString();
                //}
                //else
                //{
                agenda.Cep = reader["Cep"].ToString();
                //}
                //}
            }
            _connection.Close();
            //Then
            Assert.Equal(expectedAgenda.Bairro, agenda.Bairro);
            Assert.Equal(expectedAgenda.Cep, agenda.Cep);
        }
    }
}
