using Application.Services;
using Core.Entities.Catalog;
using Core.Entities.Stock;
using Core.Interfaces.Catalog;
using Desktop.ViewModels.Product;
using Legacy.Interfaces.Catalog;
using Moq;
using Tests.Lib.Data;
using Tests.Lib.Seed;
using Xunit;

namespace Desktop.Tests.ViewModels
{
    public class CreateProductViewModelTests
    {
        [Fact]
        public void Given_Drug_Entity_Passed_When_Calling_Method_To_Create_New_Entity_Then_Insert_Entity_On_DataSource()
        {
            //Given
            var drug = DrugSeed.BaseCreateDrugEntity();
            var fakeRepository = new FakeRepository<Drug>();
            var viewModel = new CreateProductViewModel(new DrugService(fakeRepository),new FakeRepository<Manufacturer>());
            //When
            viewModel.CreateDrugCommand.Execute(drug);
            var createdDrug = fakeRepository.GetBy(drug.Id);
            //Then
            Assert.Equal(1,createdDrug.Id);
        }
        private IDrugProdutoMediator CreateFakeDrugProdutoMediator(FakeRepository<Drug> fakeRepository)
        {
            var mockDrugProdutoMediator = new Mock<IDrugProdutoMediator>();
            mockDrugProdutoMediator.Setup(m => m.CreateDrugFrom(It.IsAny<Drug>()))
            .Callback((Drug drug) => fakeRepository.Add(drug));
            return mockDrugProdutoMediator.Object;
        }
    }
}