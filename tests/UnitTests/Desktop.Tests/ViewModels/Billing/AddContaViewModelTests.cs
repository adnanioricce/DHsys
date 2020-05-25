using Moq;
using System;
using System.Collections.Generic;
using Desktop.Models;
using Xunit;
using Core.Interfaces;
using Desktop.ViewModels.Billings;
using Application.Services;
using Tests.Lib.Data;
using Core.Entities.Financial;

namespace Desktop.Tests.ViewModels
{
    public class AddContaViewModelTests
    {        
        
        [Fact]
        public void CreateConta_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var contas = new List<Billing>();
            var fakeRepository = GetMockRepository(contas);
            var fakeBeneficiaryRepository = new FakeRepository<Beneficiary>();
            var viewModel = new CreateBillingViewModel(new BillingService(fakeRepository,fakeBeneficiaryRepository));
            var model = new ContaModel {
                DataDeVencimento = DateTime.UtcNow.AddDays(30).ToShortDateString(),
                NomeEmpresa = "empresa",
                Valor = 123.99m,
                EstaPago = false
            };
            fakeBeneficiaryRepository.Add(new Beneficiary
            {
                Name = "empresa"
            });

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
            var viewModel = new CreateBillingViewModel(new BillingService(new FakeRepository<Billing>(),null));
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
        private IBillingService GetFakeBillingService(Billing billing)
        {
            var mockBillingService = new Mock<IBillingService>();
            mockBillingService.Setup(b => b.AddBilling(It.IsAny<Billing>()))
                .Returns(new Core.Models.BaseResult<Billing>
                {
                    Errors = null,
                    Success = true,
                    Value = billing
                });
            return mockBillingService.Object;
        }
    }
}
