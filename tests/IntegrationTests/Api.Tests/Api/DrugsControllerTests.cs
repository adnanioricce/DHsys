using System.IO;
using Api.Controllers.Api;
using AspNetCore.Http.Extensions;
using Core.Entities.Catalog;
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
using Api.Tests.Seed;
using Core.ApplicationModels.Dtos.Catalog;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Tests
{
    public class DrugsControllerTests : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;
        private readonly TestFixture<Startup> _fixture;
        public DrugsControllerTests(TestFixture<Startup> fixture)
        {            
            _fixture = fixture;
            _client = _fixture.Client;
        }        
        [Fact]
        public async Task GET_GetDrugsByName_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var baseUrl = "api/Drugs/search/list?name={0}&api-version=1.0";                                    
            var drug = DrugSeed.GetDataForHttpGetMethods().FirstOrDefault();
            var context = _fixture.GetRemoteContext();
            context.Add(drug);
            context.SaveChanges();
            string requestUrl = string.Format(baseUrl, drug.DrugName);
            // Act            
            var result = await _client.GetAsync(requestUrl);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsJsonAsync<BaseResourceResponse<IList<DrugDto>>>();            
            // Assert                        
            Assert.True(response.Success);
            Assert.True(response.ResultObject.Count() > 0);
        }

        [Fact]
        public async Task GET_GetDrugByBarCode_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string baseUrl = "api/Drugs/search/{0}?api-version=1.0";                                    
            var drug = DrugSeed.GetDataForHttpGetMethods().FirstOrDefault();
            var context = _fixture.GetRemoteContext();
            context.Add(drug);
            context.SaveChanges();
            string requestUrl = string.Format(baseUrl, drug.BarCode);
            // Act
            //var result = drugsController.GetDrugByBarCode(barCode);
            var result = await _client.GetAsync(requestUrl);           
            result.EnsureSuccessStatusCode();
            var valueResult = await result.Content.ReadAsJsonAsync<BaseResourceResponse<Drug>>();
            // Assert

            Assert.NotNull(valueResult);
            Assert.Equal(drug.BarCode,valueResult.ResultObject.BarCode);
        }                

        [Fact]
        public async Task POST_CreateDrug_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string request_url = "api/Drugs/create?api-version=1.0";            
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
                ProdutoId = "1"
            };

            // Act
            var result = await _client.PostAsJsonAsync(request_url, drug);
            result.EnsureSuccessStatusCode();
            var valueResult = await result.Content.ReadAsJsonAsync<BaseResourceResponse>();

            // Assert            
            Assert.True(valueResult.Success);            
        }        
    }
}
