using System.Linq;
using Tests.Lib.Data;
using Xunit;
using Desktop.ViewModels.Product;
using Core.Entities.Catalog;
using Moq;
using Core.Interfaces;
using System.Threading.Tasks;

namespace Desktop.Tests.ViewModels
{
    public class ProductListViewModelTest
    {
        [Fact]
        public void ExecuteGetProductByCode_ReceivesSequenceOfNumbersInString_ShouldReturnAProductOnDataSourceThatMatchesGivenSequence()
        {
            //Given
            string code = "123456789012";
            var entry = new Drug
            {
                UniqueCode = code,
            };
            //var repository = new FakeLegacyProdutoRepository();            
            var mockDrugService = new Mock<IProductService>();
            mockDrugService.Setup(m => m.GetDrugByUniqueCodeAsync(It.IsAny<string>()))
                           .ReturnsAsync(entry);
            //When
            var viewModel = new ProductListViewModel(mockDrugService.Object);
            var result = viewModel.GetProductByCode(code);
            result.Wait();
            //Then                              
            Assert.NotNull(viewModel.DrugCollection.FirstOrDefault());
        }
        [Theory]
        [InlineData("ibu")]
        [InlineData("1234")]
        [InlineData("lixi")]
        public async Task ExecuteGetProductsBySearchPattern_ReceivesSearchPattern_ShouldReturnAllProductsOnDataSourceThatMatchesGivenPattern(string searchPattern)
        {
            //Given
            var drug = new Drug {
                UniqueCode = searchPattern,
                BarCode = searchPattern,
                Name = searchPattern,
                ActivePrinciple = searchPattern,
            };
            var mockDrugService = new Mock<IProductService>();
            mockDrugService.Setup(m => m.SearchDrugsByNameAsync(It.IsAny<string>()))
                           .ReturnsAsync(new[] { drug });
            var viewModel = new ProductListViewModel(mockDrugService.Object);
            //When
            await viewModel.GetProductsBySearchPattern(searchPattern);
            //Then
            Assert.NotNull(viewModel.DrugCollection.FirstOrDefault());
        }
    }
}