using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.NFe;
using Core.Entities.Catalog;
using Core.Interfaces;
using Core.Models.XML;
using Moq;
using Xunit;

namespace Services.Tests.Catalog
{
    public class SupplierDataResourceClientTest
    {
        [Fact]
        public async Task Given_NFeKey_Of_Registered_NFe_And_Passed_CNPJ_When_Send_Both_Should_Return_ProductList_On_NFe()
        {
            //Given
            string nfeKey = "";
            string cnpj = "";
            var nfeClient = new NFeDataExtractor(GetFakeNFeClient(),GetFakeDrugService());
            //When
            var result = await nfeClient.GetProdutoseServicosByNFeKey(nfeKey,cnpj);
            //Then
            Assert.True(result.Success);
        }
        [Fact]
        public async Task Given_NFeKey_Of_No_existing_NFe_When_Send_Then_Should_Return_Success_Equal_False_With_Error_Message()
        {
            //Given
            string nfeKey = Guid.NewGuid().ToString();
            string cnpj = "123.456.890";
            var nfeClient = new NFeDataExtractor(GetFakeNFeClient(),GetFakeDrugService());
            //When
            var result = await nfeClient.GetProdutoseServicosByNFeKey(nfeKey,cnpj);
            //Then
            Assert.True(!result.Success && result.Errors.Count() == 0);
        }
        [Theory]
        [InlineData("1234abc-0a/0001")]
        [InlineData("01234567890123456")]
        public async Task Given_NFeKey_Of_No_Existing_NFe_And_Invalid_CNPJ_When_Send_Both_Then_Should_Return_Success_Equal_False_With_Receive_Error_Message(string cnpj)
        {
            //Given
            string nfeKey = Guid.NewGuid().ToString();            
            var nfeClient = new NFeDataExtractor(GetFakeNFeClient(),GetFakeDrugService());
            //When
            var result = await nfeClient.GetProdutoseServicosByNFeKey(nfeKey,cnpj);
            //Then
            Assert.True(!result.Success && result.Errors.Count() == 0);
        }
        private NFeClient GetFakeNFeClient()
        {
            var fakeNfeClient = new Mock<NFeClient>();
            fakeNfeClient.Setup(f => f.GetNFeObject(It.IsAny<string>(),It.IsAny<string>()))
                         .ReturnsAsync(new xNFe{
                             InfCfe = new InfCFe{
                                 Det = new List<Det>{
                                     new Det{
                                         Prod = new Prod{
                                             CProd = "302892",
                                             XProd = "Agua Mineral Mestle",
                                             VProd = "19.22",
                                             VItem = "28.44",
                                             VUnCom = "",
                                             QCom = "",
                                             UCom = "",
                                             CFOP = "",
                                             IndRegra = ""
                                         }
                                     }
                                 }
                             }
                         });
            return fakeNfeClient.Object;
        }        
        private IDrugService GetFakeDrugService()
        {
            var fakeDrugService = new Mock<IDrugService>();
            fakeDrugService.Setup(f => f.GetDrugsByNcm(It.IsAny<IEnumerable<string>>()))
            .Returns(new Drug[]{
                new Drug{
                    Description = "fake description",
                    DigitalBuleLink = "www.fakedrug.com",
                    Dosage = "15MG",
                    DrugCost = 12.99m,
                    DrugName = "fake drug name",
                    AbsoluteDosageInMg = 15,
                    Section = "Bonificados",                    
                },
                new Drug{
                    Description = "fake description",
                    DigitalBuleLink = "www.fakedrug.com",
                    Dosage = "15MG",
                    DrugCost = 12.99m,
                    DrugName = "fake drug name",
                    AbsoluteDosageInMg = 15,
                    Section = "Bonificados",                    
                }
            });
            return fakeDrugService.Object;
        }
    }
}