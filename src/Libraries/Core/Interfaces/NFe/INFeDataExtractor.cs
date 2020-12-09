using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Catalog;
using Core.Models;
using Core.Models.ApplicationResources.Requests;

namespace Core.Interfaces.NFe
{
    public interface INFeDataExtractor
    {
        Task<BaseResult<IEnumerable<Product>>> GetProdutoseServicos(GetProductsFromNFeRequest request);
        
    }
}