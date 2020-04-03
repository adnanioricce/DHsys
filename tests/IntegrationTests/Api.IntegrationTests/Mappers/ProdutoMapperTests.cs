using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
using Core.Interfaces;
using Core.Mappers;
using System;
using System.Collections.Generic;
using Xunit;

namespace Api.IntegrationTests.Mappers
{
    public class ProdutoMapperTests
    {
        private readonly ILegacyRepository<Produto> _produtoRepository;
        private readonly IRepository<Drug> _drugRepository;
        public ProdutoMapperTests(ILegacyRepository<Produto> produtoRepository, IRepository<Drug> drugRepository)
        {
            _produtoRepository = produtoRepository;
            _drugRepository = drugRepository;
        }
        [Fact]
        public void MapTable_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var produtoMapper = new ProdutoMapper(_produtoRepository, _drugRepository);
            string tableName = "PRODUTO.DBF";

            // Act
            var result = (List<Drug>)produtoMapper.MapTable(tableName);

            // Assert            
            Assert.Equal(5129,result.Count);
        }        
        [Fact]
        public void GetChanges_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var produtoMapper = new ProdutoMapper(_produtoRepository, _drugRepository);
            string tableName = "PRODUTO.DBF";

            // Act
            var result = produtoMapper.GetChanges(tableName);

            // Assert
            Assert.True(false);
        }

        [Fact]
        public void PersistChanges_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var produtoMapper = new ProdutoMapper(_produtoRepository, _drugRepository);
            IEnumerable<Drug> changedEntities = new Drug[] {
                new Drug
                {
                    
                }
            };

            // Act
            produtoMapper.PersistChanges(changedEntities);

            // Assert
            Assert.True(false);
        }

    }
}
 
