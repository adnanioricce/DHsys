using Core.Entities.Media;

namespace Core.Entities.Catalog
{
    public class ProductMedia : BaseEntity
    {
        public int MediaResourceId { get; set; }
        public virtual MediaResource Media { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public bool IsThumbnail { get; set; }        
    }
}