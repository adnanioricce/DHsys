using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Catalog;

namespace Core.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(int start,int end);
        Task<IEnumerable<Product>> GetProductsAsync(int start,int end);        
        Product SearchProductByBarCode(string barCode);
        Task<Product> SearchProductByBarCodeAsync(string barCode);
        Product GetProductByUniqueCode(string uniqueCode);        
        Task<Product> GetProductByUniqueCodeAsync(string uniqueCode);        
        IEnumerable<Product> GetProductsByNcm(IEnumerable<string> ncms);
        IEnumerable<Product> SearchProductsByName(string name);
        Task<IEnumerable<Product>> SearchProductsByNameAsync(string name);
        void CreateProduct(Product product);
        Task CreateProductAsync(Product product);
        void CreateProducts(IEnumerable<Product> products);
        Task CreateProductsAsync(IEnumerable<Product> products);
        void UpdateProductPrice(int productId,ProductPrice newProductPrice);
        void UpdateProduct(int productId,Product product);
    }
}