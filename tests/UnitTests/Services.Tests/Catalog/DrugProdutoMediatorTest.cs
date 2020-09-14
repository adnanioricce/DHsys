//using System.Linq;
//using Core.Entities.Catalog;
//using Core.Entities.Legacy;
//using Core.Interfaces;
//using Core.Interfaces.Catalog;
//using Moq;
//using Tests.Lib.Data;
//using Tests.Lib.Seed;
//using Xunit;

//namespace Services.Tests.Catalog
//{
//    public class DrugProdutoMediatorTest
//    {
//        [Fact]
//        public void Given_New_Drug_Entity_Received_When_Call_Create_Method_Then_Insert_It_On_Local_Data_Source()
//        {
//            //Given
//            var drug = DrugSeed.BaseCreateDrugEntity();        
//            var fakeRepository = new FakeRepository<Drug>();
//            var fakeLegacyRepository = new FakeLegacyProdutoRepository();
//            // var fakeMapper = new 
//            var service = new DrugProdutoMediator(CreateFakeDrugService(fakeRepository),CreateFakeProdutoService(fakeLegacyRepository),CreateFakeDataMapper(drug,new Produto()));
//            //When
//            service.CreateDrugFrom(drug);
//            //Then
//            var createdDrug = fakeRepository.GetBy(drug.Id);            
//            Assert.Equal(1,createdDrug.Id);            
//        }
//        [Fact]
//        public void Given_New_Produto_Entity_Received_When_Call_Create_Method_Then_Insert_It_On_Local_Data_Source()
//        {
//            //Given
//            var produto = ProdutoSeed.BaseCreateProdutoEntity();        
//            var fakeRepository = new FakeRepository<Drug>();
//            var fakeLegacyRepository = new FakeLegacyProdutoRepository();
//            // var fakeMapper = new 
//            var service = new DrugProdutoMediator(CreateFakeDrugService(fakeRepository),CreateFakeProdutoService(fakeLegacyRepository),CreateFakeDataMapper(new Drug(),produto));
//            //When
//            service.CreateDrugFrom(produto);
//            //Then
//            // var createdDrug = fakeRepository.GetBy(produto.Id);
//            var createdProduto = fakeLegacyRepository.GetAll().FirstOrDefault();
//            Assert.Equal(1,createdProduto.Id);            
//        }
//        private IDrugService CreateFakeDrugService(FakeRepository<Drug> repository)
//        {
//            var mockDrugService = new Mock<IDrugService>();
//            mockDrugService.Setup(m => m.CreateDrug(It.IsAny<Drug>()))
//            .Callback((Drug drug) => repository.Add(drug));
//            return mockDrugService.Object;
//        }
//        private IProdutoService CreateFakeProdutoService(FakeLegacyProdutoRepository produtoRepository)
//        {
//            var mockProdutoService = new Mock<IProdutoService>();
//            mockProdutoService.Setup(m => m.CreateProduto(It.IsAny<Produto>()))
//            .Callback((Produto produto) => produtoRepository.Add(produto));
//            return mockProdutoService.Object;
//        }
//        private ILegacyDataMapper<Drug,Produto> CreateFakeDataMapper(Drug drug,Produto produto)
//        {
//            var mockDataMapper = new Mock<ILegacyDataMapper<Drug,Produto>>();
//            mockDataMapper.Setup(m => m.MapToLegacyModel(It.IsAny<Drug>()))
//                          .Returns(produto);
//            mockDataMapper.Setup(m => m.MapToDomainModel(It.IsAny<Produto>()))
//                          .Returns(drug);
//            return mockDataMapper.Object;
//        }
//    }
//}