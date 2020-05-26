namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class UpdatesController : ControllerBase
    {
        private readonly string _appUpdateFolder = "~/appUpdates/";
        public UpdatesController()
        {
            
        }
        [HttpPost]
        public async Task<BaseResult<object>> UploadUpdatePackage(IFormFile file)
        {
            //TODO:validate the request
            using var reader = new StreamReader(file.OpenReadStream());
            var content = await reader.ReadToEndAsync();
            ZipArchive archive = ZipFile.OpenRead(content);
            foreach (ZipArchiveEntry entry in archive)
            {
                string destinationPath = Path.GetFullPath(Path.Combine(_appUpdateFolder,entry.Name));
                if (destinationPath.StartsWith(extractPath, StringComparison.Ordinal))
                    entry.ExtractToFile(destinationPath);
            }
        }
    }    
}