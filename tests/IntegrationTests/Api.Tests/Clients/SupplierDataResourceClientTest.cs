using Application.Services;
using Core.Interfaces;
using Core.Models.Resources.Requests;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests
{
    public class SupplierDataResourceClientTest
    {
        private readonly IDataResourceClient _supplierResourceClient;
        public SupplierDataResourceClientTest()
        {
            _supplierResourceClient = new SupplierDataResourceClient("base-url.com/path");
        }
        [Fact]
        public async Task GetExternalResource_ReceivesUniqueNumberStringAndUserCnpj_ShouldReturnAllStocksRetrievedFromResource()
        {
            //Given
            var getResourceRequest = new GetStockResourceRequest{                
                UniqueNumber = "",
                Cnpj = ""
            };                                                
            //When
            var result = await _supplierResourceClient.GetExternalResource(getResourceRequest);
            //Then
            Assert.True(result.Success);
        }
    }
}
