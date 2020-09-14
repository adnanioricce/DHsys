using Application.Services.Sync;
using Core.Entities;
using DAL.DbContexts;
using DAL.Extensions;
using DAL.Interfaces;
using Infrastructure.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.IntegrationTests.Services.Sync
{
    public class DbSyncronizerTests
    {
        private readonly RemoteContext _remoteContext;
        public DbSyncronizerTests(DbContextResolver contextResolver)
        {
            _remoteContext = (RemoteContext)contextResolver("remote");            
            var models = _remoteContext.Model.GetEntityTypes().Select(e => e.GetTableName());
        }
        [Fact]
        public async Task Given_local_context_with_unsynced_state_with_remote_context_When_Calls_Sync_method_With_remote_context_Then_start_sync_operation()
        {
            // Given             
            var localContext = CreateContext();
            var service = new DbSyncronizer(null,null, GetFakeLogger<DbSyncronizer>());
            // When 
            _remoteContext.Add(new Address {
                Id = 1,
                UniqueCode = Guid.NewGuid().ToString(),                
            });
            var result = await service.SyncLocalDbWithRemoteDbAsync(localContext,_remoteContext);
            var localEntities = localContext.Model.GetEntityTypes();
            var remoteEntities = _remoteContext.Model.GetEntityTypes();
            // Then
            Assert.True(result.Success);
            Assert.Equal(remoteEntities.Count(), localEntities.Count());
            localContext.Dispose();
        }        
        private LocalContext CreateContext()
        {
            var context = new LocalContext(CreateOptions(new SqliteConnection($"DataSource={Guid.NewGuid().ToString()}.db")));            
            return context;
        }

        private DbContextOptions<LocalContext> CreateOptions(SqliteConnection connection)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LocalContext>();
            optionsBuilder.UseSqlite(connection);
            return optionsBuilder.Options;
        }
        private IAppLogger<T> GetFakeLogger<T>()
        {
            var mockLogger = new Mock<IAppLogger<T>>();
            mockLogger.Setup(m => m.LogInformation(It.IsAny<string>(), "arg 1"))
                .Verifiable();
            mockLogger.Setup(m => m.LogError(It.IsAny<string>(), "arg 1"))
                .Verifiable();
            return mockLogger.Object;
        }
    }
}
