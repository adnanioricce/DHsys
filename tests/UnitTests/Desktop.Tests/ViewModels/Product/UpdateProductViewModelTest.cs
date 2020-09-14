using Core.Entities;
using Core.Entities.Catalog;
using Core.Entities.Financial;
using Core.Entities.Legacy;
using Core.Interfaces;
using Core.Interfaces.Catalog;
using Desktop.ViewModels.Product;
using Moq;
using Tests.Lib.Data;
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
            var viewModel = new UpdateProductViewModel(GetFakeDrugProdutoMediator());
            // When
            viewModel.UpdateProductCommand.Execute(productModel);
            // Then
            Assert.Equal(4,productModel.QuantityInStock);
        }        

        private IDrugProdutoMediator GetFakeDrugProdutoMediator()
        {
            var fakeDrugProdutoMediator = new Mock<IDrugProdutoMediator>();
            fakeDrugProdutoMediator.Setup(m => m.UpdateDrugFrom(It.IsAny<Drug>()))
                .Callback((Drug drug) => drug.QuantityInStock = 4);
            return fakeDrugProdutoMediator.Object;
            //var drugProdutoMediator = new DrugProdutoMediator()
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
