using System.Text;
using System.Reflection;
using Application.Services;
using Core.Interfaces;
using Core.Models.Dbf;
using Core.Models.ApplicationResources.Requests;
using DAL;
using dBASE.NET;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Xunit;
using Application;
using Microsoft.EntityFrameworkCore;
using Legacy.Entities;
using Application.Windows.Services.Sync;

namespace Api.IntegrationTests.Services.Sync
{
    public class LegacyDbSyncronizerTests : IDisposable
    {
        private readonly DbContext _context;
        private readonly IDbConnection _sourceConnection;
        private readonly LegacyDbSynchronizer _dbSyncronizer;
        
        public LegacyDbSyncronizerTests(LegacyDbSynchronizer dbSyncronizer, DbContext context)
        {
            //_connection = new SqliteConnection("Data Source=database.db");            
            _context = context;
            _dbSyncronizer = dbSyncronizer;
        }

        public void Dispose()
        {
            _context.Dispose();
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
            request.RecordDiffs.Add(1,new RecordDiff
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
            var connection = _context.Database.GetDbConnection();
            connection.Open();
            var command = connection.CreateCommand();
            var insertScript = $"INSERT INTO AGENDA(LastUpdatedOn,Bairro,Cep) VALUES(CURRENT_TIMESTAMP,{string.Join(',', request.RecordDiffs[1].ColumsChanged.Select(c => $"'{c.Value}'"))})";
            command.CommandText = insertScript;
            var insertResult = command.ExecuteNonQuery();
            connection.Close();
            //When
            var syncScript = _dbSyncronizer.GenerateSyncScriptForEntity(request);
            connection.Open();
            command.CommandText = syncScript;
            int syncResult = command.ExecuteNonQuery();
            Assert.Equal(1,syncResult);
        }
        [Fact]
        public void WhenDataSourceFilesChange_WriteAllChangesOnLocalDataSource_ThenReturnAffectedNumberOfRecords()
        {
            //Given                 
            string dataSourceFolder = "./TestData/Source";                      
            //When            
            int result = _dbSyncronizer.SyncSourceDatabaseWithLocalDatabase(dataSourceFolder);
            //Then
            Assert.Equal(189,result);
        }        
        private void WriteDbfToWhenDataSourceFilesChangesNeedTestData(IEnumerable<object> data,string dbfPath)
        {
            var dbf = new Dbf();
            var fields = data.FirstOrDefault()
                            .GetType()
                            .GetProperties()
                            .Select(ToDbfField)
                            .Where(f => !(f is null));                                                                
            dbf.Fields.AddRange(fields);                        
            var values = data.Select(d => d.GetType()
                                           .GetProperties()
                                           .Select(p => p.GetValue(d))
                                           .Where(p => !(p is null)));
                                           
            foreach (var value in values){
                var record = dbf.CreateRecord();
                record.Data.AddRange(value);
                dbf.Records.Add(record);
            }            
            dbf.Write(dbfPath,DbfVersion.FoxBaseDBase3NoMemo);                     
        }        
        private DbfField ToDbfField(PropertyInfo property)
        {
            if(property.PropertyType.Name == nameof(String)){
                return new DbfField(property.Name,DbfFieldType.Character,32);
            }
            if(property.PropertyType.Name == nameof(Single)){
                return new DbfField(property.Name,DbfFieldType.Float,sizeof(System.Single));
            }
            if(property.PropertyType.Name == nameof(Double)){
                return new DbfField(property.Name,DbfFieldType.Double,sizeof(System.Double));
            }
            if(property.PropertyType.Name == nameof(Int32)){
                return new DbfField(property.Name,DbfFieldType.Integer,sizeof(System.Int32));
            }
            if(property.PropertyType.Name == nameof(DateTime)){
                return new DbfField(property.Name,DbfFieldType.Date,32);
            }
            if(property.PropertyType.Name == nameof(Boolean)){
                return new DbfField(property.Name,DbfFieldType.Logical,1);
            }            
            return null;
        }
    }
}
