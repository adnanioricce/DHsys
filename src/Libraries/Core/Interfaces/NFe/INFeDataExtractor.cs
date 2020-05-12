using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Catalog;
using Core.Models;

namespace Core.Interfaces.NFe
{
    public interface INFeDataExtractor
    {
        Task<BaseResult<IEnumerable<Drug>>> GetProdutoseServicosByNFeKey(string nfeKey, string cnpj);
        
    }
}