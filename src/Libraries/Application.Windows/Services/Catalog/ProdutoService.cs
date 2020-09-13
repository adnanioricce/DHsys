using Core.Entities.Catalog;
using Core.Entities.Legacy;
using Core.Interfaces;
using Core.Interfaces.Catalog;
using DAL.Windows.Repositories;
using System.Linq;

namespace Application.Windows.Services.Catalog
{
    public class ProdutoService : IProdutoService
    {        
        private readonly ILegacyRepository<Produto> _produtoLegacyRepository;
        private readonly IRepository<Produto> _produtoDomainRepository;
        public ProdutoService(//IRepository<Produto> produtoDomainRepository,
        ILegacyRepository<Produto> produtoLegacyRepository)
        {            
            _produtoLegacyRepository = produtoLegacyRepository;
            //_produtoDomainRepository = produtoDomainRepository;
            
        }        
        public virtual void CreateProduto(Produto produto)
        {
            //_produtoDomainRepository.Add(produto);
            //_produtoDomainRepository.SaveChanges();
            _produtoLegacyRepository.Add(produto);                     
        }

        public virtual void UpdateProduto(Produto produto)
        {
            //_produtoDomainRepository.Update(produto);
            //_produtoDomainRepository.SaveChanges();
            //var updateColumns = string.Join(',', produto.GetType()
            //    .GetProperties()
            //    .Select(p => $"{p.Name}=@{p.Name}"));
            //var sql = $"UPDATE Produto SET {updateColumns} WHERE prcodi = {produto.Prcodi};";
            //_produtoLegacyRepository.Command(sql,produto);
            _produtoLegacyRepository.Add(produto);
        }
    }
}