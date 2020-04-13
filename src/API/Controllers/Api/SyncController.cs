
using Core.Models.Resources.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Controllers.Api
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class SyncController : ControllerBase
    {        
        public SyncController()
        {

        }
        [HttpPost("sync_dbfs")]
        public async Task<IActionResult> SyncDatabase([FromBody]SyncDatabaseRequest request)
        {
            

            return NoContent();
        }
        private int GetIndexOfLastBackslash(string filepath)
        {
            return filepath.IndexOf("/") == -1 ? filepath.LastIndexOf("\\") : filepath.LastIndexOf("/");
        }
        private T CastObject<T>(object input)
        {
            return (T)input;
        }
    }
}
