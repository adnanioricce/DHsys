using Legacy.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces.Catalog
{
    //TODO:Use a mediator between this interface and IDrugService
    public interface IProdutoService
    {        
        void CreateProduto(Produto produto);
        void UpdateProduto(Produto produto);        
    }
}