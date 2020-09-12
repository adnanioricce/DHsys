using System.IO;
using Api.Controllers.Api;
using AspNetCore.Http.Extensions;
using Core.Entities.Catalog;
using Core.Entities.Legacy;
using Core.Interfaces;
using Core.Models.ApplicationResources;
using Core.Models.ApplicationResources.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Tests.Lib;
using Xunit;

namespace Api.Tests
{
    public class DrugsControllerTests : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;

        public DrugsControllerTests(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }

        //public DrugsControllerTests(TestFixture<Startup> fixture)
        //{
        //    _client = fixture.Client;            
        //}
        [Fact]
        public async Task GET_GetDrugsByName_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var baseUrl = "api/Drugs/search/list?name={0}";            
            string name = "Dipirona";
            string requestUrl = string.Format(baseUrl, name);
            // Act
            //var result = _client.get
            var result = await _client.GetAsync(requestUrl);
            var valueResult = await result.Content.ReadAsJsonAsync<BaseResourceResponse<IEnumerable<Drug>>>();
            // Assert
            var count = valueResult.ResultObject.Count();
            Assert.True(valueResult.Success);
            Assert.True(count > 0);
        }

        [Fact]
        public async Task GET_GetDrugByBarCode_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string baseUrl = "api/Drugs/search/{0}";            
            string barCode = "1234567890123";
            string requestUrl = string.Format(baseUrl, barCode);
            // Act
            //var result = drugsController.GetDrugByBarCode(barCode);
            var result = await _client.GetAsync(requestUrl);           
            result.EnsureSuccessStatusCode();
            var valueResult = await result.Content.ReadAsJsonAsync<BaseResourceResponse<Drug>>();
            // Assert

            Assert.NotNull(valueResult);
            Assert.Equal(barCode,valueResult.ResultObject.BarCode);
        }

        [Fact]
        public async Task POST_CreateDrugsFromCollectionOfProduto_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string request_url = "api/Drugs/create_from_produtos";            
            var data = new CreateDrugFromProdutoRequest
            {
                CreatedProdutos = new List<Produto>
                {
                    new Produto
                    {
                        Prcodi = "123456",
                        Prbarra = "1234567890123",
                        Prdesc = "Dipirona GTS 5mg",
                        Pricms = 18,
                        EstMinimo = 1,
                        Prestq = 3,
                        Premb = 1,
                        Prncms = "3000333333",
                        Prfabr = 4.24,
                        Prcons = 12.50,
                        DescMax = 20,
                        Prprinci = "some principle",
                        Secao = "",
                        Ultfor = "Fornecedor"
                    }
                }
            };

            // Act
            var result = await _client.PostAsJsonAsync(request_url, data);
            result.EnsureSuccessStatusCode();
            var valueResult = await result.Content.ReadAsJsonAsync<BaseResourceResponse<IEnumerable<Drug>>>();
            // Assert            
            Assert.True(string.IsNullOrEmpty(valueResult.Message));            
            Assert.True(valueResult.Success);
        }

        [Fact]
        public async Task POST_CreateDrugFromProduto_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string request_url = "api/Drugs/create_from_produto";
            Produto produto = GetBaseProduto();

            // Act            
            var result = await _client.PostAsJsonAsync(request_url,produto);
            result.EnsureSuccessStatusCode();
            var valueResult = await result.Content.ReadAsJsonAsync<BaseResourceResponse>();
            // Assert
            Assert.True(string.IsNullOrEmpty(valueResult.Message));
            Assert.True(valueResult.Success);
        }

        [Fact]
        public async Task POST_CreateDrug_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string request_url = "api/Drugs/create";            
            var drug = new Drug { 
                DrugName = "Dipirona GTS 5mg",
                Description = "Dipirona GTS 5mg",
                DiscountValue = 0,
                Ncm = "300025567889",
                IsPriceFixed = false,
                EndCustomerPrice = 10m,
                Section = "Bonificados",
                ReorderLevel = 1,
                ReorderQuantity = 5,
                QuantityInStock = 2,
                UniqueCode = "123456",
                //Produto = GetBaseProduto()
                ProdutoId = 1
            };

            // Act
            var result = await _client.PostAsJsonAsync(request_url, drug);
            result.EnsureSuccessStatusCode();
            var valueResult = await result.Content.ReadAsJsonAsync<BaseResourceResponse>();

            // Assert
            Assert.True(string.IsNullOrEmpty(valueResult.Message));
            Assert.True(valueResult.Success);            
        }
        private Produto GetBaseProduto()
        {
            return new Produto
            {
                Prcodi = "123456",
                Prbarra = "1234567890123",
                Prdesc = "Dipirona GTS 5mg",
                Pricms = 18,
                EstMinimo = 1,
                Prestq = 3,
                Premb = 1,
                Prncms = "3000333333",
                Prfabr = 4.24,
                Prcons = 12.50,
                DescMax = 20,
                Prprinci = "some principle",
                Secao = "",
                Ultfor = "Fornecedor"
            }; 
        }
    }
}
