using UI.Entities;
using DAL;
using System.Linq;
using UI.ViewModels;
using Xunit;
using Tests.Lib.Data;

namespace UI.Tests.ViewModels
{
    public class ContaListViewModelTests
    {                        

        [Fact]
        public void OnSearch_StateUnderTest_ExpectedBehavior()
        {
            // Arrange            
            var viewModel = new ContaListViewModel(new FakeRepository<Conta>());
            string value = "1";

            // Act
            viewModel.OnSearch(value);

            // Assert
            Assert.True(viewModel.Contas.All(item => item.NomeEmpresa.Contains(value)));            
        }

        [Fact]
        public void CanSearch_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var viewModel = new ContaListViewModel(null);
            object parameter = null;

            // Act
            var result = viewModel.CanSearch(parameter);

            // Assert
            Assert.True(result);            
        }
    }
}
