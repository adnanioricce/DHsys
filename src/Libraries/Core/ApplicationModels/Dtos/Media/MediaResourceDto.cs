using Core.Entities.Media;

namespace Core.ApplicationModels.Dtos.Media
{
    public class MediaResourceDto : BaseEntityDto
    {        
        public long Size { get; set; }

        public MediaType Type { get; set; }

        public string SourceUrl { get; set; }

        public string Caption { get; set; }

        public static MediaResourceDto FromModel(MediaResource model)
        {
            return new MediaResourceDto()
            {
                Size = model.Size, 
                Type = model.Type, 
                SourceUrl = model.SourceUrl, 
                Caption = model.Caption, 
            }; 
        }

        public MediaResource ToModel()
        {
            return new MediaResource()
            {
                Size = Size, 
                Type = Type, 
                SourceUrl = SourceUrl, 
                Caption = Caption, 
            }; 
        }
    }
}