using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
using Core.Interfaces;
using Core.Mappers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Lib.Data;
using Xunit;

namespace Services.Tests.Mappers
{
    public class ProdutoMapperTests
    {        
        public (FakeRepository<Drug> drugRepository,FakeLegacyProdutoRepository produtoRepository) GetRepositories()
        {
            return (new FakeRepository<Drug>(),new FakeLegacyProdutoRepository());
        }
        [Fact]        
        public void MapTable_ReceivesLegacyTableName_ShouldReturnListOfEntitiesMappedFromRowsInLegacyTable()
        {
            // Arrange
            var produtoList = new List<Produto>();
            var data = Data;
            foreach (var item in data)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    produtoList.Add((Produto)(item[i]));
                }
            }
            var produtoRepository = new FakeLegacyProdutoRepository(produtoList);
            
            var produtoMapper = new LegacyTableMapper(null,produtoRepository,null);
            string tableName = "PRODUTO";
            
            // Act
            var result = produtoMapper.MapTable(tableName);
            var isValid = IsValidMapping(result, produtoList);
            // Assert
            Assert.True(isValid);
        }

        [Theory,MemberData(nameof(Data))]
        public void MapToDomainModel_ReceivesLegacyDomainModel_ShouldReturnAVersionOfThisModelInTheCurrentModel(Produto sampleProduto)
        {
            // Arrange            
            var produtoMapper = new LegacyTableMapper(null,null,null);            

            // Act
            var result = produtoMapper.MapToDomainModel(sampleProduto);

            // Assert
            //TODO:this only work with one test case
            Assert.True(result.Dosage.Contains("G") || result.Dosage.Contains("L"));
            Assert.Equal(sampleProduto.Id, result.ProdutoId);
            Assert.Equal(sampleProduto.Prfinal, (double)result.EndCustomerPrice);
            Assert.Equal(18,result.ICMS);
            Assert.Equal(!string.IsNullOrEmpty(sampleProduto.Prlote), result.PrescriptionNeeded && !string.IsNullOrEmpty(result.LotNumber));
        }

        [Fact]
        public void GetChanges_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var produtoMapper = new LegacyTableMapper(null,null, null);
            string tableName = null;

            // Act
            var result = produtoMapper.GetChanges(tableName);

            // Assert
            Assert.True(false);            
        }
       
        private bool IsValidMapping(IEnumerable<Drug> drugList,IEnumerable<Produto> produtoList)
        {
            //? this probably isn't any better than use two for loops to find this out
            //? What's the time of this?
            return new HashSet<Drug>(drugList).Any(d => produtoList.Any(p => IsValidDrugForSituation(d, p)));
        }        
        private bool IsValidDrugForSituation(Drug drug,Produto produto)
        {
            return (drug.Dosage.Contains("G") || drug.Dosage.Contains("L"))
                && produto.Id == drug.ProdutoId
                && produto.Prfinal == (double)drug.EndCustomerPrice
                && drug.ICMS != 18
                && (!string.IsNullOrEmpty(produto.Prlote)
                    ? drug.PrescriptionNeeded && !string.IsNullOrEmpty(drug.LotNumber)
                    : false);
        }
        public static IEnumerable<object[]> Data 
        {
            get {
                var dataList = new List<Produto[]>{
                    new Produto[] {
                        new Produto{
                            Prbarra = "12346789101112131415",
                            Prcodi = "123456",
                            Prdesc = "*ISORDIL SUBLINGUAL 5MG C/30",
                            Prncms = "300212345",
                            Prclas = "C",
                            Pretiq = "",
                            Prestq = 2.0d,
                            Prcdse = "01",
                            Prprinci = "DINITRATO DE ISOSSORBIDA",
                            Prlote = "1234",
                            Prnola = "NQ",
                            Prfabr = 32.95,
                            Prfinal = 50.00,
                            EstMinimo = 1d,
                            DescMax = 30,
                            Prloca = "ETICO",
                            Prnose = "ETICOS",
                            Ultfor = "SupplierNumberOne"

                        }
                    }
                };
                
                return dataList.Select(d => new object[] { d });
            }
    }
        

    }
}
