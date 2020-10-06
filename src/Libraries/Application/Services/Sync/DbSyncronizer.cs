using Core.Entities;
using Core.Entities.Sync;
using Core.Interfaces;
using Core.Models;
using DAL.DbContexts;
using DAL.Extensions;
using DAL.Interfaces;
using Dotmim.Sync;
using Dotmim.Sync.Sqlite;
using Dotmim.Sync.SqlServer;
using Infrastructure.Interfaces;
using Infrastructure.Settings;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql;
using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Application.Services.Sync
{
    public class DbSyncronizer : IDbSyncronizer
    {        
        private readonly RemoteContext _remoteContext;
        private readonly LocalContext _localContext;
        private readonly IOptions<DatabaseSettings> _dbSettings;
        private readonly IAppLogger<DbSyncronizer> _logger;        
        public DbSyncronizer(DbContextResolver contextResolver,
                            IOptions<DatabaseSettings> dbSettings,
                            IAppLogger<DbSyncronizer> logger)
        {
            if (!(contextResolver is null))
            {
                _remoteContext = (RemoteContext)contextResolver("remote");
                _localContext = (LocalContext)contextResolver("local");
            }
            _dbSettings = dbSettings;
            _logger = logger;
        }       
        public async Task<BaseResult<object>> SyncLocalDbWithRemoteDbAsync(LocalContext localContext,RemoteContext remoteContext)
        {
            var (remoteConnection, localConnection) = (remoteContext.Database.GetDbConnection(),localContext.Database.GetDbConnection());            
            var (serverProvider, clientProvider) = (GetSqlSyncProvider(remoteConnection),GetSqlSyncProvider(localConnection));
            var tableNames = remoteContext.Model.GetEntityTypes()
                                                .Select(e => e.GetTableName())
                                                .Distinct()
                                                .ToArray();            
            var agent = new SyncAgent(clientProvider, serverProvider,tableNames);
            var syncContext = await agent.SynchronizeAsync(Dotmim.Sync.Enumerations.SyncType.Reinitialize);
            _logger.LogInformation($"Syncronization result:{syncContext.ToString()}");
            return new BaseResult<object> {
                Value = syncContext,
                Success = true,
            };
        }
        private CoreProvider GetSqlSyncProvider(IDbConnection connection)
        {
            if (connection is SqlConnection)
            {
                return new SqlSyncProvider(connection.ConnectionString);
            }
            if (connection is SqliteConnection)
            {
                return new SqliteSyncProvider(connection.ConnectionString);
            }                                  
            string connectionName = !(connection is null) ? connection.GetType().Name : "no connection";
            string message = $"the sql connection {connectionName} can't be used to as sync provider";
            var exception = new ArgumentException();
            _logger.LogStackTrace(message, exception);
            throw exception;
        }        
        public async Task<BaseResult<object>> SyncLocalDbWithRemoteDbAsync()
        {
            return await SyncLocalDbWithRemoteDbAsync(_localContext, _remoteContext);
        }
        private bool IsValidConnectionString(string connectionString)
        {
            var connStrBuilder = new DbConnectionStringBuilder();
            try
            {
                connStrBuilder.ConnectionString = connectionString;
                return true;
            }catch(ArgumentException exception)
            {
                var errorMessage = $"the connection string passed on {nameof(IsValidConnectionString)} in class {this.GetType().Name}:{connectionString} is not valid";
                var exceptionMessage = $"Exception Message:\n{exception.Message}";
                _logger.LogStackTrace(errorMessage,exception);
                return false;
            }
        }        
        private void RemoteFirstOrDefault<T>() where T : BaseEntity
        {
            var unUsed = _remoteContext.Set<T>().FirstOrDefault();
        }
    }
}
