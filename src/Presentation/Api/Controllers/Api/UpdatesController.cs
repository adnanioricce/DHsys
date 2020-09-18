using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UpdatesController : ControllerBase
    {
        private readonly string _appUpdateFolder = "~/appUpdates/";
        public UpdatesController()
        {
            
        }
        [HttpPost]
        public async Task<IActionResult> UploadUpdatePackage(IFormFile file)
        {
            //TODO:validate the request
            using var reader = new StreamReader(file.OpenReadStream());
            var content = await reader.ReadToEndAsync();
            ZipArchive archive = ZipFile.OpenRead(content);
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                string destinationPath = Path.GetFullPath(Path.Combine(_appUpdateFolder,entry.Name));
                if (destinationPath.StartsWith(_appUpdateFolder, StringComparison.Ordinal))
                    entry.ExtractToFile(destinationPath);
            }
            return Ok("files uploaded with success");
        }
    }    
}