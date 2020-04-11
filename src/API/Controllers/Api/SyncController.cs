using Api.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
            for(int i = 0;i < request.RecordDiffs.Count; ++i)
            {
                if (!(request.RecordDiffs[i].IsNew))
                {
                    string typeName = request.FileName.Substring(GetIndexOfLastBackslash(request.FileName));
                    var type = Type.GetType(typeName,throwOnError:true,ignoreCase:true);
                    var record = Convert.ChangeType(request.RecordDiffs[i].Value, type);
                    var fields = record.GetType().GetProperties().Select(p => new { 
                        FieldName = p.Name,
                        Value = p.GetValue()
                    })

                }
            }
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
