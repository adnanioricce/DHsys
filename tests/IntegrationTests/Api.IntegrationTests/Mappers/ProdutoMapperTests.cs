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
            // Given
            var produtoMapper = new ProdutoMapper(_legacyProdutoRepository);
            string tableName = "PRODUTO.DBF";

            // When
            var result = produtoMapper.MapTable(tableName);

            // Then            
            Assert.Equal(5005, result.Count());
        }                                      

    }
}
 
