using Application.Services.Catalog;
using Core.Entities.LegacyScaffold;
using Tests.Lib.Data;
using Tests.Lib.Seed;
using Xunit;

namespace Services.Tests.Catalog
{
    public class ProdutoServiceTest
    {
        [Fact]
        public void Given_Received_Entity_Produto_Object_When_passed_to_Create_Method_Service_Should_Then_Create_Record_In_Source_and_local_DataSource()
        {
            //Given
            var produto = ProdutoSeed.BaseCreateProdutoEntity();
            var fakeProduto = new FakeRepository<Produto>();
            var fakeLegacyProduto = new FakeLegacyProdutoRepository();
            var service = new ProdutoService(fakeProduto,fakeLegacyProduto);
            //When
            service.CreateProduto(produto);
            var createdProduto = fakeProduto.GetBy(produto.Id);
            //Then
            Assert.Equal(1,createdProduto.Id);
        }
    }
}