using Core.Entities;
using DAL.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using UI.Models;
using UI.ViewModels;
using Xunit;

namespace UI.Tests.ViewModels
{
    public class AddContaViewModelTests
    {
        private readonly List<Conta> contas = new List<Conta>();
        
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
        private IRepository<Conta> GetMockRepository()
        {
            var mockRepo = new Mock<IRepository<Conta>>();
            mockRepo.Setup(r => r.Add(It.IsAny<Conta>()))
                .Callback((Conta entity) => contas.Add(entity));
            mockRepo.Setup(r => r.SaveChanges())
                .Callback(() => Console.WriteLine("saved"));
            return mockRepo.Object;
        }
    }
}
