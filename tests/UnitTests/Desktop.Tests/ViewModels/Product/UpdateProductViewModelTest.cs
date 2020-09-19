using Application.Services;
using Core.Entities;
using Core.Entities.Catalog;
using Core.Entities.Financial;
using Core.Interfaces;
using Desktop.ViewModels.Product;
using Legacy.Interfaces.Catalog;
using Moq;
using Tests.Lib.Seed;
using Xunit;

namespace Desktop.Tests.ViewModels.ProductViewModelsTests
{
    public class UpdateProductViewModelTest
    {
        [Fact]
        public void Given_ProductModel_On_ViewModel_When_User_Sends_Command_With_Model_Parameter_Then_Update_Entity_And_Model_on_ViewModel()
        {
            // Given
            var productModel = DrugSeed.BaseCreateDrugEntity();            
            var viewModel = new UpdateProductViewModel(GetFakeDrugService());
            // When
            viewModel.UpdateProductCommand.Execute(productModel);
            // Then
            Assert.Equal(4,productModel.QuantityInStock);
        }        

        private IDrugService GetFakeDrugService()
        {
            var fakeDrugProdutoMediator = new Mock<IDrugService>();
            fakeDrugProdutoMediator.Setup(m => m.UpdateDrug(It.IsAny<int>(),It.IsAny<Drug>()))
                .Callback((Drug drug) => drug.QuantityInStock = 4);
            return fakeDrugProdutoMediator.Object;            
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
