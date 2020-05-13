using System;
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
            var StartDate = DateTime.UtcNow.AddDays(-DateTime.UtcNow.Subtract(new DateTime(0, 0, 1)).TotalSeconds);
            var EndDate = DateTime.UtcNow;
            var result = await nfeClient.GetNFeObject(StartDate,EndDate,nfeKey,1,cnpj);
            //Then
            Assert.Equal(nfeKey,result.InfCfe.Id);
        }
    }
}