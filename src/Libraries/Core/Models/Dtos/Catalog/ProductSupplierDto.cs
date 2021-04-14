using Core.Models.Dtos.Stock;

namespace Core.Models.Dtos.Catalog
{
    public class ProductSupplierDto : BaseEntityDto
    {        
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int SupplierId { get; set; }
        public SupplierDto Supplier { get; set; }
    }
}