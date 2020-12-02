
using Core.Interfaces;
using Core.Interfaces.Catalog;
using DAL.Windows.Repositories;
using Legacy.Entities;

namespace Application.Windows.Services.Catalog
{
    public class ProdutoService : IProdutoService
    {        
        private readonly ILegacyRepository<Produto> _produtoLegacyRepository;        
        public ProdutoService(ILegacyRepository<Produto> produtoLegacyRepository)
        {            
            _produtoLegacyRepository = produtoLegacyRepository;                        
        }        
        public virtual void CreateProduto(Produto produto)
        {            
            _produtoLegacyRepository.Add(produto);                     
        }

        public virtual void UpdateProduto(Produto produto)
        {            
            _produtoLegacyRepository.Add(produto);
        }
    }
}