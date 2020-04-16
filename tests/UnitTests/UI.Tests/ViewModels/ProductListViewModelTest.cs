using System.Linq;
using Tests.Lib.Data;
using Xunit;
using Core.Entities.LegacyScaffold;
using UI.ViewModels.Product;

namespace UI.Tests.ViewModels
{
    public class ProductListViewModelTest
    {
        [Fact]
        public void ExecuteGetProductByCode_ReceivesSequenceOfNumbersInString_ShouldReturnAProductOnDataSourceThatMatchesGivenSequence()
        {
            //Given
            string code = "123456789012";
            var entry = new Produto{
                Prcodi = code,
            };
            var repository = new FakeLegacyProdutoRepository();
            repository.Add(entry);
            //When
            var viewModel = new ProductListViewModel(repository);
            viewModel.ExecuteGetProductByCode(entry.Prcodi);
            //Then                              
            Assert.NotNull(viewModel.ProdutoCollection.FirstOrDefault());
        }
        [Theory]
        [InlineData("ibu")]
        [InlineData("1234")]
        [InlineData("lixi")]
        public void ExecuteGetProductsBySearchPattern_ReceivesSearchPattern_ShouldReturnAllProductsOnDataSourceThatMatchesGivenPattern(string searchPattern)
        {
            //Given            
            var repository = new FakeLegacyProdutoRepository();
            repository.Add(new Produto
            {
                Prcodi = searchPattern,
                Prbarra = searchPattern,
                Prdesc = searchPattern,
                Prprinci = searchPattern,                
            });
            var viewModel = new ProductListViewModel(repository);
            //When
            viewModel.ExecuteGetProductsBySearchPattern(searchPattern);
            //Then
            Assert.NotNull(viewModel.ProdutoCollection.FirstOrDefault());
        }
          
    }
}