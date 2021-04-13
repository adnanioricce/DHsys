using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.ApplicationModels.Dtos.Catalog;
using Core.Entities.Catalog;
using Core.Interfaces;
using Core.Models.ApplicationResources;
using Core.Validations;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Api.Controllers
{    
    public class ProductController : DefaultApiController<Product,ProductDto>
    {
        private readonly IProductService _ProductService;        
        public ProductController(IRepository<Product> ProductRepository,IMapper mapper,BaseValidator<Product> ProductValidator, IProductService ProductService) : base(ProductRepository,mapper,ProductValidator)
        {
            _ProductService = ProductService;
        }
        
        // GET: api/Products/search/list?name={name}
        [HttpGet("search/list")]
        public async Task<ActionResult<BaseResourceResponse<IList<ProductDto>>>> GetProductsByName([FromQuery]string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Log.Information("Error 404 when trying to search for Products with given name, name parameter was null.");
                return StatusCode(404, BaseResourceResponse.GetFailureResponseWithMessage("name parameter is null"));
            }
            var products = await _ProductService.SearchProductsByNameAsync(name);
            if(!products.Any())
            {                
                Log.Information("404 error returned on ProductsController for name {name}",name);
                return StatusCode(404, new BaseResourceResponse<IList<ProductDto>>
                {
                    Message = $"there is no Product with the pattern {name} on it's name",
                    Success = false,
                });
            }
            var ProductDtos = _mapper.Map<List<Product>, IList<ProductDto>>(products.ToList());
            var resultValue = new BaseResourceResponse<IList<ProductDto>>("Products created with success", ProductDtos);
            return Ok(resultValue);
        }
        // GET: api/Products/search/{barcode}
        [HttpGet("search/{barcode}")]
        public async Task<ActionResult<BaseResourceResponse<ProductDto>>> GetProductByBarCode([FromRoute]string barcode)
        {
            var Product = await _ProductService.SearchProductByBarCodeAsync(barcode);
            if (Product is null)
            {
                Log.Information("404 error returned on ProductsController for barcode {barcode}", barcode);
                return StatusCode(404, new BaseResourceResponse<ProductDto>
                {
                    Message = $"There is no Product with barcode {barcode}",
                    ResultObject = null
                });
            }
            return Ok(new BaseResourceResponse<ProductDto>("Product entry created successfully", _mapper.Map<Product,ProductDto>(Product)));            
        }                        
    }
}
