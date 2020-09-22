using Core.Entities.Media;

namespace Core.Entities.Catalog
{
    public class ProductMedia : BaseEntity
    {
        public int MediaResourceId { get; set; }
        public MediaResource Media { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
