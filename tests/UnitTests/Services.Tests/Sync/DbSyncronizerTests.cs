using Application.Services;
using Core.Entities.LegacyScaffold;
using Core.Models.Dbf;
using Core.Models.Resources.Requests;
using DAL;
using System;
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
                        Value = "nome bairro"
                    },
                    new RecordColumn
                    {
                        ColumnName = "CEP",
                        Value = "123456789"
                    }
                }
            });
            string expectedScript = "UPDATE Agenda SET BAIRRO='nome bairro',CEP='123456789' WHERE Id = 1;";            
            var dbSyncronizer = new DbSynchronizer(null);
            //When
            string syncScript = dbSyncronizer.GenerateSyncScriptForEntity(request);
            //Then
            Assert.Equal(expectedScript, syncScript);
        }
        [Fact]
        public void WriteUpdateSetToCorrectSqlType_ReceivesRecordColumnWithValuesOfTypeDoubleAndDateTime_ShouldReturnSqlUpdateStringWithValuesInCorrectTypeFormInSql()
        {
            //Given
            var firstColumn = new RecordColumn
            {
                ColumnName = "PRESTQ",
                Value = 1
            };
            var maturity = DateTime.UtcNow;
            var secondColumn = new RecordColumn
            {
                ColumnName = "PRVALID",
                Value = maturity
            };
               
            string expectedStringForStr1 = "PRESTQ=1";
            string expectedStringForStr2 = $"PRVALID={maturity}";
            var dbSyncronizer = new DbSynchronizer(null);
            //When
            string resultStr1 = dbSyncronizer.WriteUpdateSetToCorrectSqlType(firstColumn);
            string resultStr2 = dbSyncronizer.WriteUpdateSetToCorrectSqlType(secondColumn);
            //Then
            Assert.Equal(expectedStringForStr1, resultStr1);
            Assert.Equal(expectedStringForStr2, resultStr2);
        }
    }
}
