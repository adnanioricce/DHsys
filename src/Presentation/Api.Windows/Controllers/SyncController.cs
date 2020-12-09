using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading.Tasks;
using Application;
using MediatR;
using Legacy.Interfaces.Sync;
using Legacy.Models.Sync;

namespace Api.Windows.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SyncController : ControllerBase
    {
        private readonly ILegacyDbSynchronizer _dbSyncronizer;
        private readonly IDbConnection _connection;        
        private readonly string _dbfSourceFolder = "C://Dbfs"; // need something to load the source path from
        public SyncController(ILegacyDbSynchronizer dbSynchronizer,
            ConnectionResolver connection,
            IMediator mediator)
        {
            #warning don't load windows specific libs here
            _dbSyncronizer = dbSynchronizer;
            _connection = connection("remote");                        
        }
        [HttpPost("sync_dbfs")]
        public async Task<IActionResult> SyncDatabase([FromBody]SyncDatabaseRequest request)
        {
            if (request is null) return BadRequest("Request is null");
            if (request.RecordDiffs.Count == 0) return BadRequest("request has no record to sync");
            if (string.IsNullOrEmpty(request.TableName)) return BadRequest("we need the modified table name to sync the database");
            var result = await Task.Run<int>(() =>
            {
                var syncScript = _dbSyncronizer.GenerateSyncScriptForEntity(request);
                _connection.Open();
                var command = _connection.CreateCommand();
                command.CommandText = syncScript;
                var result = command.ExecuteNonQuery();
                _connection.Close();
                return result;
            });
            if(!(result != -1))
            {
                return StatusCode(500, "not all changes are writen on database");
            }             
            
            return Ok("all changes are writen successfully");
        }                 
        [HttpGet("sync_databases")]      
        public async Task<IActionResult> SyncSourceDatabaseWithDatabaseLocalDatabase()
        {
            //? How do I now if this is failing or not?
            //if this is alreadly executing, how do I lock to avoid concurrency issues?
            //TODO:Wrap this on worker service
            var result = await Task.Run<int>(() => _dbSyncronizer.SyncSourceDatabaseWithLocalDatabase(_dbfSourceFolder));
            
            return Ok("Success");
        }
        
        
    }
}
