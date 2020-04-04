using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
using Core.Interfaces;
using Core.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Api.IntegrationTests.Mappers
{
    public class ProdutoMapperTests
    {
        private readonly ILegacyRepository<Produto> _legacyProdutoRepository;
        private readonly IRepository<Produto> _produtoRepository;
        private readonly IRepository<Drug> _drugRepository;
        public ProdutoMapperTests(IRepository<Produto> produtoRepository,ILegacyRepository<Produto> legacyProdutoRepository, IRepository<Drug> drugRepository)
        {
            _produtoRepository = produtoRepository;
            _legacyProdutoRepository = legacyProdutoRepository;
            _drugRepository = drugRepository;
        }
        [Fact]
        public void MapTable_ReceivesTableName_ShouldReturnListOfEntitiesMappedFromLegacyModel()
        {
            // Arrange
            var produtoMapper = new ProdutoMapper(_produtoRepository,_legacyProdutoRepository, _drugRepository);
            string tableName = "PRODUTO.DBF";

            // Act
            var result = produtoMapper.MapTable(tableName);

            // Assert            
            Assert.Equal(5005, result.Count());
        }        
        [Fact]
        public void GetChanges_ReceivesTableName_ShouldReturnListComparingChangesBetween()
        {
            // Arrange
            var produtoMapper = new ProdutoMapper(_produtoRepository,_legacyProdutoRepository, _drugRepository);
            string tableName = "PRODUTO.DBF";

            // Act
            var result = produtoMapper.GetChanges(tableName);

            // Assert
            Assert.True(false);
        }
        
        [Fact]
        public void SaveLegacyModelOnDatabase_ReceivesTableName_ShouldPersistsLegacyEntitiesOnCurrentDatabase() 
        {
            // Arrange
            var produtoMapper = new ProdutoMapper(_produtoRepository, _legacyProdutoRepository, _drugRepository);
            // Act
            produtoMapper.SaveLegacyModelOnDatabase("PRODUTO.DBF");
            // Assert
            var produtos = _produtoRepository
                .Query()
                .Take(30);
            var count = produtos.Count();
            Assert.Equal(30, count);
        }

    }
}
 
