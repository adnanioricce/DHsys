using System.IO;
using Api.Controllers.Api;
using AspNetCore.Http.Extensions;
using Core.Entities.Catalog;
using Core.Interfaces;
using Core.Models.ApplicationResources;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Core.ApplicationModels.Dtos.Catalog;
using DAL.Seed;

namespace Api.Tests
{
    public class ProductControllerTests : ControllerTestBase<Product, ProductDto>
    {        
        public ProductControllerTests(ApiTestFixture fixture) : base(fixture)
        {                        
        }        
        [Fact]
        public async Task GET_GetDrugsByName_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var baseUrl = "api/Product/search/list?name={0}&api-version=1.0";
            var drug = new ProductSeed().GetSeedObject();
            var context = _fixture.GetContext();
            context.Add(drug);
            context.SaveChanges();
            string requestUrl = string.Format(baseUrl, drug.Name);
            // Act            
            var result = await _client.GetAsync(requestUrl);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsJsonAsync<BaseResourceResponse<IList<ProductDto>>>();            
            // Assert                        
            Assert.True(response.Success);
            Assert.True(response.ResultObject.Count() > 0);
        }

        [Fact]
        public async Task GET_GetDrugByBarCode_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string baseUrl = "api/Product/search/{0}?api-version=1.0";                                    
            var Product = new ProductSeed().GetSeedObject();
            var context = _fixture.GetContext();
            context.Add(Product);
            context.SaveChanges();
            string requestUrl = string.Format(baseUrl, Product.BarCode);
            // Act
            //var result = drugsController.GetDrugByBarCode(barCode);
            var result = await _client.GetAsync(requestUrl);           
            result.EnsureSuccessStatusCode();
            var valueResult = await result.Content.ReadAsJsonAsync<BaseResourceResponse<ProductDto>>();
            // Assert
            Assert.NotNull(valueResult);
            Assert.Equal(Product.BarCode,valueResult.ResultObject.BarCode);
        }                

        [Fact]
        public async Task POST_CreateDrug_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string request_url = "api/Product/create?api-version=1.0";            
            var Product = new ProductDto
            { 
                Name = "Dipirona GTS 5mg",
                RegistryCode = "1234",
                UseRestriction = "Infantil",
                Description = "Dipirona GTS 5mg",
                DiscountValue = 0,
                Ncm = "300025567889",
                IsPriceFixed = false,
                EndCustomerPrice = 10m,
                Section = "Bonificados",
                ReorderLevel = 1,
                ReorderQuantity = 5,
                QuantityInStock = 2,                 
            };

            // Act
            var result = await _client.PostAsJsonAsync(request_url, Product);
            result.EnsureSuccessStatusCode();
            var valueResult = await result.Content.ReadAsJsonAsync<BaseResourceResponse>();

            // Assert            
            Assert.True(valueResult.Success);            
        }        
    }
}
