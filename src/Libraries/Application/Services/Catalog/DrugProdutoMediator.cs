using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
using Core.Interfaces;
using Core.Interfaces.Catalog;

namespace Application.Services.Catalog
{
    public class DrugProdutoMediator : IDrugProdutoMediator
    {
        private readonly IDrugService _drugService;
        private readonly IProdutoService _produtoService;
        private readonly ILegacyDataMapper<Drug,Produto> _produtoMapper;
        public DrugProdutoMediator(IDrugService drugService,IProdutoService produtoService,ILegacyDataMapper<Drug,Produto> produtoMapper)
        {
            _drugService = drugService;
            _produtoService = produtoService;
            _produtoMapper = produtoMapper;
        }
        public void CreateDrugFrom(Produto produto)
        {
            var drug = _produtoMapper.MapToDomainModel(produto);
            _produtoService.CreateProduto(produto);            
            _drugService.CreateDrug(drug);
        }

        public void CreateDrugFrom(Drug drug)
        {
            var produto = _produtoMapper.MapToLegacyModel(drug);
            _produtoService.CreateProduto(produto);
            _drugService.CreateDrug(drug);
        }

        public void UpdateDrugFrom(Drug drug)
        {
            //_drugService.
        }
    }
}