using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Catalog;
using Core.Interfaces;
using Core.Interfaces.NFe;
using Core.Models;
using Core.Models.ApplicationResources.Requests;
using Core.Models.XML;

namespace Application.Services.NFe
{
    public class NFeDataExtractor : INFeDataExtractor
    {
        private readonly INFeClient _nfeClient;
        private readonly IProductService _drugService;
        public NFeDataExtractor(INFeClient nfeClient,IProductService drugService)
        {
            _nfeClient = nfeClient;
            _drugService = drugService;
        }
        public async Task<BaseResult<IEnumerable<Product>>> GetProdutoseServicos(GetProductsFromNFeRequest request)
        {
            var nfe = await _nfeClient.GetNFeObject(request.StartDate,request.EndDate,request.NFeKey,1,request.CNPJ);
            //! Get By NCM, check if CProd is the NCM
            var ncms = nfe.InfCfe.Det.Select(d => d.Prod.CProd);
            var existingDrugs = _drugService.GetProductsByNcm(ncms);
            var newNcms = ncms.Where(ncm => existingDrugs.Any(d => string.Equals(d.Ncm,ncm,StringComparison.CurrentCultureIgnoreCase)));
            var newDrugs = nfe.InfCfe.Det.Where(d => newNcms.Any(ncm => string.Equals(ncm,d.Prod.CProd)))
                                         .Select(d => ConvertProdToProduct(d.Prod));            
            return new BaseResult<IEnumerable<Product>>{
                Value = Enumerable.Union(existingDrugs,newDrugs),
                Success = true                
            };
        }
        private Product ConvertProdToProduct(Prod prod)
        {
            var product = new Product
            {
                Description = prod.XProd,
                UniqueCode = prod.CProd,                                
                DiscountValue = 20,
                MaxDiscountPercentage = 20,
                Section = "Varejo"
            };
            var isValidPrice = decimal.TryParse(prod.VProd, out decimal costPrice);
            var price = ProductPrice.CreateNewPrice(product, isValidPrice ? costPrice : Convert.ToDecimal(prod.VProd), costPrice * 1.5m, DateTimeOffset.UtcNow);
            product.SetNewPrice(price);
            return product;
        }
    }
}