using System.Data;
using Application.Services;
using Core.Entities.LegacyScaffold;
using Core.Models.Dbf;
using Core.Models.ApplicationResources.Requests;
using DAL;
using System;
using System.Collections.Generic;
using Tests.Lib.Data;
using Xunit;
using Microsoft.Data.Sqlite;
using System.Data.OleDb;

namespace Services.Tests.Sync
{
    public class DbSyncronizerTests
    {
        // [Fact]
        // public void GenerateSyncScript_ReceivesRequestWithTableNameEqualAGENDAAnd1RecordDiffWithIsNewEqualToFalse_ShouldReturnSqlScriptWithUpdateQueryOnlyForChangedColumns()
        // {
        //     //Given
        //     var request = new SyncDatabaseRequest
        //     {
        //         TableName = "AGENDA"
        //     };
        //     request.RecordDiffs.Add(1, new RecordDiff
        //     {
        //         RecordIndex = 1,
        //         RecordValue = new Agenda
        //         {
        //             Bairro = "nome bairro",
        //             Cep = "123456789",
        //             Cidade = "nome cidade",
        //             Codigo = "123456",
        //             Endereco = "nome endereço",
        //             Fone = "3455643",
        //             Nome = "um nome"
        //         },
        //         ColumsChanged = new List<RecordColumn>
        //         {
        //             new RecordColumn
        //             {
        //                 ColumnName = "BAIRRO",
        //                 Value = "nome bairro"
        //             },
        //             new RecordColumn
        //             {
        //                 ColumnName = "CEP",
        //                 Value = "123456789"
        //             }
        //         }
        //     });
        //     string expectedScript = "UPDATE Agenda SET BAIRRO='nome bairro',CEP='123456789' WHERE Id = 1;";            
        //     var dbSyncronizer = new DbSynchronizer(GetDbConnection);
        //     //When
        //     string syncScript = dbSyncronizer.GenerateSyncScriptForEntity(request);
        //     //Then
        //     Assert.Equal(expectedScript, syncScript);
        // }
        // [Fact]
        // public void WriteUpdateSetToCorrectSqlType_ReceivesRecordColumnWithValuesOfTypeDoubleAndDateTime_ShouldReturnSqlUpdateStringWithValuesInCorrectTypeFormInSql()
        // {
        //     //Given
        //     var firstColumn = new RecordColumn
        //     {
        //         ColumnName = "PRESTQ",
        //         Value = 1
        //     };
        //     var maturity = DateTime.UtcNow;
        //     var secondColumn = new RecordColumn
        //     {
        //         ColumnName = "PRVALID",
        //         Value = maturity
        //     };
               
        //     string expectedStringForStr1 = "PRESTQ=1";
        //     string expectedStringForStr2 = $"PRVALID={maturity}";
        //     var dbSyncronizer = new DbSynchronizer(GetDbConnection);
        //     //When
        //     string resultStr1 = dbSyncronizer.WriteUpdateSetToCorrectSqlType(firstColumn);
        //     string resultStr2 = dbSyncronizer.WriteUpdateSetToCorrectSqlType(secondColumn);
        //     //Then
        //     Assert.Equal(expectedStringForStr1, resultStr1);
        //     Assert.Equal(expectedStringForStr2, resultStr2);
        // }
        private IDbConnection GetDbConnection(string key){
            return key switch 
                {
                    //our local database
                    "local" => new SqliteConnection("Data Source=InMemorySample;Mode=Memory;Cache=Shared"),
                    //a legacy shared database from which source changes in real world environment
                    "source" => new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\dbfs;Extended Properties=dBASE IV;User ID='';Password='';"),
                    //a remote database to keep some changes
                    // "remote" => new NpgsqlConnection(remoteConnString),
                    _ => throw new KeyNotFoundException("there is no IDbConnection registered that match the given key")
                };
        }
    }
}
