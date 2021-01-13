using Core.Entities.Financial;

namespace Core.Entities.Catalog
{
    public class ProductTax : BaseEntity
    {
        public ProductTax(Product product,int productId, Tax tax,int taxId)
        {
            TaxId = taxId;
            Tax = tax;
            ProductId = productId;
            Product = product;
        }
        public ProductTax(Product product,Tax tax)
        {
            Product = product;
            Tax = tax;
        }
        public ProductTax(int productId,int taxId)
        {
            ProductId = productId;
            TaxId = taxId;
        }
        public int TaxId { get; protected set; }
        public Tax Tax { get; protected set; }
        public int ProductId { get; protected set; }
        public Product Product { get; protected set; }
    }
}
