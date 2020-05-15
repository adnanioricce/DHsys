
using Moq;
using System;
using System.Collections.Generic;
using Desktop.Models;
using Desktop.ViewModels;
using Xunit;
using Desktop.Interfaces;
using Core.Interfaces;
using Core.Entities;
using Desktop.ViewModels.Billings;

namespace Desktop.Tests.ViewModels
{
    public class AddContaViewModelTests
    {        
        
        [Fact]
        public void CreateConta_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contas = new List<Billing>();
            var viewModel = new CreateBillingViewModel(GetMockRepository(contas));
            var model = new ContaModel {
                DataDeVencimento = DateTime.UtcNow.AddDays(30).ToShortDateString(),
                NomeEmpresa = "empresa",
                Valor = 123.99m,
                EstaPago = false
            };

            // Act
            viewModel.CreateConta(model);

            // Assert            
            Assert.Single(contas);
        }

        [Fact]
        public void CanCreateConta_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contas = new List<Billing>();
            var viewModel = new CreateBillingViewModel(GetMockRepository(contas));
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
        private IRepository<Billing> GetMockRepository(List<Billing> contas)
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
