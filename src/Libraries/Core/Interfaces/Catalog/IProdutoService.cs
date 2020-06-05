using Core.Entities.Catalog;
using Core.Entities.Legacy;

namespace Core.Interfaces.Catalog
{
    //TODO:Use a mediator between this interface and IDrugService
    public interface IProdutoService
    {        
        void CreateProduto(Produto produto);
        void UpdateProduto(Produto produto);

    }
}