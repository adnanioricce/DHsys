using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
using Core.Interfaces;
using Core.Interfaces.Catalog;

namespace Application.Services.Catalog
{
    public class ProdutoService : IProdutoService
    {        
        private readonly ILegacyRepository<Produto> _produtoLegacyRepository;
        private readonly IRepository<Produto> _produtoDomainRepository;
        public ProdutoService(IRepository<Produto> produtoDomainRepository
        ,ILegacyRepository<Produto> produtoLegacyRepository)
        {            
            _produtoLegacyRepository = produtoLegacyRepository;
            _produtoDomainRepository = produtoDomainRepository;
            
        }        
        public void CreateProduto(Produto produto)
        {
            _produtoDomainRepository.Add(produto);
            _produtoDomainRepository.SaveChanges();
            _produtoLegacyRepository.Add(produto);                     

        }
    }
}