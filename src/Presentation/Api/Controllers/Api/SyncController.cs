using Core.Entities;
using Core.Interfaces;
using Core.Models.Resources.Requests;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Controllers.Api
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class SyncController : ControllerBase
    {
        private readonly IDbSynchronizer _dbSyncronizer;
        private readonly IDbConnection _connection;
        public SyncController(IDbSynchronizer dbSynchronizer,IDbConnection connection)
        {
            _dbSyncronizer = dbSynchronizer;
            _connection = connection;
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
    }
}
