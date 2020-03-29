using Core.Entities;
using DAL;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq;
using Core.ViewModels;
using Xunit;

namespace Core.Tests.ViewModels
{
    public class ContaListViewModelTests
    {                        

        [Fact]
        public void OnSearch_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            using var context = new FakeContext();
            var viewModel = new ContaListViewModel(new Repository<Conta>(context));
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
