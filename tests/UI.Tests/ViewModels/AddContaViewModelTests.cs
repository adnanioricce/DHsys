
using Moq;
using System;
using System.Collections.Generic;
using UI.Models;
using UI.ViewModels;
using Xunit;
using UI.Interfaces;
using Core.Interfaces;
using Core.Entities;

namespace UI.Tests.ViewModels
{
    public class AddContaViewModelTests
    {
        private readonly List<Billing> contas = new List<Billing>();
        
        [Fact]
        public void CreateConta_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var viewModel = new AddContaViewModel(GetMockRepository());
            var model = new ContaModel {
                DataDeVencimento = DateTime.UtcNow.AddDays(30).ToShortDateString(),
                NomeEmpresa = "empresa",
                Valor = 123.99m,
                EstaPago = false
            };

            // Act
            viewModel.CreateConta(model);

            // Assert            
            Assert.Equal(1,contas.Count);
        }

        [Fact]
        public void CanCreateConta_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var viewModel = new AddContaViewModel(GetMockRepository());
            var model = new ContaModel
            {
                DataDeVencimento = "01/11/20",
                NomeEmpresa = "empresa",
                Valor = 123.99m,
                EstaPago = false
            };

            // Act
            var result = viewModel.CanCreateConta(model);

            // Assert
            Assert.True(result);
        }
        private IRepository<Billing> GetMockRepository()
        {
            var mockRepo = new Mock<IRepository<Billing>>();
            mockRepo.Setup(r => r.Add(It.IsAny<Billing>()))
                .Callback((Billing entity) => contas.Add(entity));
            mockRepo.Setup(r => r.SaveChanges())
                .Callback(() => Console.WriteLine("saved"));
            return mockRepo.Object;
        }
    }
}
