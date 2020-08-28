using Core.Entities.Catalog;
using Core.Interfaces.Catalog;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Desktop.ViewModels.Product
{
    public class UpdateProductViewModel : ViewModelBase
    {
        private readonly IDrugProdutoMediator _drugProdutoMediator;
        public RelayCommand<Drug> UpdateProductCommand { get; set; }
        public UpdateProductViewModel(IDrugProdutoMediator drugProdutoMediator)
        {
            _drugProdutoMediator = drugProdutoMediator;
            UpdateProductCommand = new RelayCommand<Drug>(_drugProdutoMediator.UpdateDrugFrom);
        }
        

    }
}
