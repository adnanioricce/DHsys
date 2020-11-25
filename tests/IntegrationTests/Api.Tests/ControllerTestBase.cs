using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.Http.Extensions;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Models.ApplicationResources;
using DAL.Seed;
using Simple.OData.Client;
using Tests.Lib;
using Xunit;

namespace Api.Tests
{
    public abstract class ControllerTestBase<TEntity,TEntityDto> : IClassFixture<ApiTestFixture> where TEntity : BaseEntity 
                                                                                                 where TEntityDto : class 
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
        protected readonly IDataObjectSeed<TEntity> _seeder;
        protected readonly ApiTestFixture _fixture;
        protected readonly HttpClient _client;
        protected readonly ODataClient _odataClient;
        public ControllerTestBase(ApiTestFixture fixture)
        {            
            _repository = (IRepository<TEntity>)fixture.ServiceProvider.GetService(typeof(IRepository<TEntity>));
            _mapper = (IMapper)fixture.ServiceProvider.GetService(typeof(IMapper));
            _seeder = (IDataObjectSeed<TEntity>)fixture.ServiceProvider.GetService(typeof(IDataObjectSeed<TEntity>));
            _client = fixture.Client;
            _odataClient = fixture.ODataClient;
            _fixture = fixture;
        }
        [Fact(DisplayName = "Test default GET method to retrieve entity by Id")]
        public virtual async Task GET_GetById_ReceivesIntegerId_ExpectedToReturnEntityMappedToDto()
        {
            //Arrange            
            string templateUrl = "api/{0}/{1}?api-version=1.0";
            var seedObject = CreateSeedObject();
            string url = String.Format(templateUrl, typeof(TEntity).Name, seedObject.Id);
            //Act
            var response = await _client.GetAsync(url);            
            //Assert
            Assert.True(response.IsSuccessStatusCode);            
        }
        [Fact(DisplayName = "Test default create method of the entity controller")]
        public virtual async Task POST_Create_ReceivesEntityObject_ExpectedToReturnCreatedEntity()
        {
            // Arrange
            var seedObject = _mapper.Map<TEntity, TEntityDto>(_seeder.GetSeedObject());
            string url = GetRequestUrl("api/{0}/create?api-version=1.0", "POST");
            // Act            
            var response = await _client.PostAsJsonAsync(url,seedObject);
            var content = await response.Content.ReadAsStringAsync();
            // Assert            
            Assert.True(response.IsSuccessStatusCode);
        }
        [Fact(DisplayName = "Test default update endpoint of the entity controller.")]
        public virtual async Task PUT_Update_ReceivesEntityObject_ExpectedToReturnUpdatedEntity()
        {
            // Arrange
            var seedObject = CreateSeedObject();            
            seedObject.UniqueCode = Guid.NewGuid().ToString();
            var url = GetRequestUrl("api/{0}/{1}?api-version=1.0", typeof(TEntity).Name, seedObject.Id);
            // Act
            var dto = _mapper.Map<TEntity, TEntityDto>(seedObject);
            var response = await _client.PutAsJsonAsync(url,dto);
            // Assert
            Assert.True(response.IsSuccessStatusCode);            
        }
        [Fact(DisplayName = "Test default delete endpoint of the entity controller")]
        public virtual async Task DELETE_Delete_ReceivesEntityId_ExpectedToReturnDefaultSuccessResponse()
        {
            //Arrange
            var seedObject = CreateSeedObject();
            var url = GetRequestUrl("api/{0}/{1}?api-version=1.0", typeof(TEntity).Name, seedObject.Id);
            // Act
            var response = await _client.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
            // Assert
            Assert.True(response.IsSuccessStatusCode);

        }
        [Fact(DisplayName = "Test the validation endpoint")]
        public virtual async Task POST_ValidateCreate_ReceivesEntityObject_ExpectedToReturnValidationResultObject()
        {
            // Arrange
            var seedObject = _seeder.GetSeedObject();            
            var url = $"api/{typeof(TEntity).Name}/validate-create?api-version=1.0";
            // Act
            var response = await _client.PostAsJsonAsync(url, seedObject);
            // Assert
            //only need to know if the endpoint tries to validate the object sended
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }        

        protected string GetRequestUrl(string templateUrl,string method,int id = 0)
        {
            if (method.ToUpper() == "POST")
            {                                  
                return String.Format(templateUrl, typeof(TEntity).Name);
            }
            return String.Format(templateUrl, typeof(TEntity).Name, id);
        }
        protected TEntity CreateSeedObject()
        {
            var seedObject = _seeder.GetSeedObject();
            _repository.Add(seedObject);
            _repository.SaveChanges();
            return seedObject;
        }
    }
}
