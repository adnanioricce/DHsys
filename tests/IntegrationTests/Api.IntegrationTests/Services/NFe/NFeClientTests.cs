using System.Threading.Tasks;
using Application.Services.NFe;
using Xunit;

namespace Api.IntegrationTests.Services.NFe
{
    public class NFeClientTests
    {

        [Theory]
        [InlineData("012345678901234567891234567890","123456-21/0001")]
        public async Task Given_NFe_Registered_On_Passed_CNPJ_When_Send_Both_NFeKey_and_CNPJ_Then_Return_NFe_Object(string nfeKey,string cnpj)
        {
            //Given
            var nfeClient = new NFeClient();
            //When
            var result = await nfeClient.GetNFeObject(nfeKey,cnpj);
            //Then
            Assert.Equal(nfeKey,result.InfCfe.Id);
        }
    }
}