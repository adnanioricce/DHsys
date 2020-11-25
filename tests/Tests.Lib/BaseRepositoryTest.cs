using Core.Entities;
using Core.Interfaces;
using DAL;
using DAL.DbContexts;
using DAL.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Lib
{

    public class BaseRepositoryTest<TEntity> : IDisposable where TEntity : BaseEntity
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IDataObjectSeed<TEntity> _seeder;
        protected readonly BaseContext _context;
        public BaseRepositoryTest()
        {
            _context = DbContextHelper.CreateContext();
            _context.Database.OpenConnection();
            _context.Database.EnsureCreated();
            _repository = new Repository<TEntity>(_context);
            var dataObjectSeedType = Assembly.GetAssembly(typeof(DALAssembly))
                    .GetTypes()
                    .Where(t => t.GetInterfaces().Any(it => it.IsGenericType && it.Name == typeof(IDataObjectSeed<>).Name && it.GetGenericArguments().Any(genericArgument => genericArgument == typeof(TEntity))))
                    .FirstOrDefault();
            var seederInstance = (IDataObjectSeed<TEntity>)Activator.CreateInstance(dataObjectSeedType);
            _seeder = seederInstance;            
        }
        [Fact]
        public async Task TestAdd()
        {
            // Arrange            
            var seedObject = _seeder.GetSeedObject();
            // Act
            _repository.Add(seedObject);
            var result = await _repository.SaveChangesAsync();
            var entity = _repository.Query().OrderBy(c => c.Id).LastOrDefault();            
            // Assert
            Assert.NotNull(entity);
        }
        [Fact]
        public async Task TestAddRange()
        {
            // Arrange
            var seedObjects = Enumerable.Repeat(_seeder.GetSeedObject(), 10).ToList();
            // Act
            _repository.AddRange(seedObjects);
            await _repository.SaveChangesAsync();
            // Assert
            Assert.NotEmpty(_repository.Query().ToList());            
        }        
        [Fact]
        public async Task TestGetBy()
        {
            // Arrange
            var seedObject = _seeder.GetSeedObject();
            _repository.Add(seedObject);
            await _repository.SaveChangesAsync();    
            // Act
            var entity = await _repository.GetByAsync(seedObject.Id);
            // Assert
            Assert.Equal(seedObject.Id,entity.Id);
        }
        [Fact]
        public async Task TestUpdate()
        {
            // Arrange
            var seedObject = _seeder.GetSeedObject();
            _repository.Add(seedObject);
            await _repository.SaveChangesAsync();                        
            // Act
            seedObject.UniqueCode = Guid.NewGuid().ToString();
            _repository.Update(seedObject);
            var result = await _repository.SaveChangesAsync();
            // Assert
            Assert.Equal(1,result);
        }
        [Fact]
        public async Task TestDelete()
        {
            // Arrange
            var seedObject = _seeder.GetSeedObject();
            _repository.Add(seedObject);
            var createResult = await _repository.SaveChangesAsync();
            int id = seedObject.Id;
            // Act
            _repository.Delete(seedObject);
            await _repository.SaveChangesAsync();
            var entity = await _repository.GetByAsync(id);
            // Assert
            Assert.Null(entity);
        }
        [Fact]
        public async Task TestGetAll()
        {
            // Arrange
            var seedObjects = Enumerable.Repeat(_seeder.GetSeedObject(), 10).ToList();
            _repository.AddRange(seedObjects);
            await _repository.SaveChangesAsync();
            // Act
            var entities = await _repository.GetAllAsync();
            // Assert
            Assert.NotEmpty(entities);
        }
        public void Dispose()
        {
            //_context.Database.CloseConnection();
            //_context.Dispose();
        }
    }
}
