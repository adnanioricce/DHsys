using Core.Entities.Catalog;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {                
        private readonly IRepository<Product> _productRepository;
        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
            
        }
        public virtual void CreateProduct(Product Product)
        {
            //TODO:write Product validation
            _productRepository.Add(Product);
            _productRepository.SaveChanges();
        }

        public async Task CreateProductAsync(Product product)
        {
            _productRepository.Add(product);
            await _productRepository.SaveChangesAsync();
        }

        public virtual void CreateProducts(IEnumerable<Product> products)
        {                                    
            _productRepository.AddRange(products);
            _productRepository.SaveChanges();
        }

        public async Task CreateProductsAsync(IEnumerable<Product> products)
        {
            _productRepository.AddRange(products);
            await _productRepository.SaveChangesAsync();
        }

        public virtual Product GetProductByUniqueCode(string uniqueCode)
        {
            return _productRepository.Query()
                                     .Where(d => d.UniqueCode == uniqueCode)
                                     .FirstOrDefault();
        }

        public virtual Task<Product> GetProductByUniqueCodeAsync(string uniqueCode)
        {
            return _productRepository.Query()
                                     .Where(d => d.UniqueCode == uniqueCode)
                                     .FirstOrDefaultAsync();
        }

        public virtual IEnumerable<Product> GetProducts(int start, int end)
        {
            return _productRepository.Query()
                                     .TakeWhile(d => d.Id >= start && d.Id <= end);
        }

        public virtual async Task<IEnumerable<Product>> GetProductsAsync(int start, int end)
        {
            return await _productRepository.Query()
                                           .Skip(start)
                                           .Take(end)
                                           .ToListAsync();
            
        }

        public virtual IEnumerable<Product> GetProductsByNcm(IEnumerable<string> ncms)
        {
            return _productRepository.Query()
                                     .Where(product => ncms.Any(nc => nc == product.Ncm));
        }

        public virtual Product SearchProductByBarCode(string barCode)
        {
            return _productRepository.Query()
                                    .Where(d => d.BarCode == barCode)                
                                    .FirstOrDefault();
        }

        public virtual Task<Product> SearchProductByBarCodeAsync(string barCode)
        {
            return _productRepository.Query()
                                    .Where(d => 
                                        EF.Functions.Like(d.BarCode.ToLower(), "%" + barCode.ToLower() + "%") 
                                        || EF.Functions.Like(d.UniqueCode, "%" + barCode.ToLower() + "%"))
                                    .FirstOrDefaultAsync();
        }

        public virtual IEnumerable<Product> SearchProductsByName(string name)
        {
            return _productRepository.Query().Where(d => EF.Functions.Like(d.Name.ToLower(), "%" + name.ToLower() + "%") 
                || EF.Functions.Like(d.Description.ToLower(), "%" + name.ToLower() + "%"));
        }

        public virtual async Task<IEnumerable<Product>> SearchProductsByNameAsync(string name)
        {       
            return await _productRepository.Query()
                                        .Where(d => d.Name.Contains(name))                                
                                        .ToListAsync();
        }

        public virtual void UpdateProduct(int ProductId, Product Product)
        {
            var _Product = _productRepository.GetBy(ProductId);
            if(_Product is null)
            {
                return;
            }
            _productRepository.Update(Product);
        }

        public virtual void UpdateProductPrice(int ProductId, ProductPrice newProductPrice)
        {
            //TODO:Validate Product price
            var Product = _productRepository.GetBy(ProductId);
            Product.ProductPrices.Add(newProductPrice);
            _productRepository.Update(Product);
        }
    }
}