using Core.ApplicationModels.Dtos.Stock;

namespace Core.ApplicationModels.Dtos.Catalog
{
    public class ProductSupplierDto : BaseEntityDto
    {        
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int SupplierId { get; set; }
        public SupplierDto Supplier { get; set; }
    }
}