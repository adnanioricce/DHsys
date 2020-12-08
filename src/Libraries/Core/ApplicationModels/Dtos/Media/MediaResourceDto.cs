using Core.Entities.Media;

namespace Core.ApplicationModels.Dtos.Media
{
    public class MediaResourceDto : BaseEntityDto
    {        
        public long Size { get; set; }

        public MediaType Type { get; set; }

        public string SourceUrl { get; set; }

        public string Caption { get; set; }        
    }
}