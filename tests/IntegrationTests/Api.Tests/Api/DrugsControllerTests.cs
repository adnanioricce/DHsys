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

        //public DrugsControllerTests(TestFixture<Startup> fixture)
        //{
        //    _client = fixture.Client;            
        //}
        [Fact]
        public async Task GET_GetDrugsByName_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var baseUrl = "api/Drugs/search/list?name={0}";                        
            
            var drug = DrugSeed.GetDataForHttpGetMethods().FirstOrDefault();
            var context = _fixture.GetRemoteContext();
            context.Add(drug);
            context.SaveChanges();
            string requestUrl = string.Format(baseUrl, drug.DrugName);
            // Act
            //var result = _client.get
            var result = await _client.GetAsync(requestUrl);
            var response = await result.Content.ReadAsJsonAsync<BaseResourceResponse<IList<DrugDto>>>();            
            // Assert                        
            Assert.True(response.Success);
            Assert.True(response.ResultObject.Count() > 0);
        }

        [Fact]
        public async Task GET_GetDrugByBarCode_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            string baseUrl = "api/Drugs/search/{0}";                        
            
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
                ProdutoId = "1"
            };

            // Act
            var result = await _client.PostAsJsonAsync(request_url, drug);
            result.EnsureSuccessStatusCode();
            var valueResult = await result.Content.ReadAsJsonAsync<BaseResourceResponse>();

            // Assert            
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
