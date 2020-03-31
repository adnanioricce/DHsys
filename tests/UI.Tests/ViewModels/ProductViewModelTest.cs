using System.Linq;
using System;
using UI.Entities.LegacyScaffold;
using Tests.Lib.Data;
using UI.ViewModels;
using Xunit;

namespace UI.Tests.ViewModels
{
    public class ProductViewModelTest
    {
        [Fact]
        public void GetProductByCode_ReceivesSequenceOfNumbersInString_ShouldReturnAProductOnDataSourceThatMatchesGivenSequence()
        {
            //Given
            string code = "123456789012";
            var entry = new Produto{
                Prcodi = code,
            };
            var repository = new FakeLegacyRepository<Produto>();
            repository.Add(entry);
            //When
            var viewModel = new ProductViewModel(repository);
            viewModel.ExecuteGetProductByCode(entry.Prcodi);
            //Then                  
            Assert.Equal(1,viewModel.ProdutoCollection.Count);
            Assert.NotNull(viewModel.ProdutoCollection.FirstOrDefault());
        }
        [Fact]
        public void TestName()
        {
            //Given
            
            //When
            
            //Then
        }
          
    }
}