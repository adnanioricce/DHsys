using Core.Entities.Catalog;
using Core.Interfaces;
using Core.Interfaces.Catalog;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Desktop.ViewModels.Product
{
    public class CreateProductViewModel : ViewModelBase
    {        
        private readonly IDrugProdutoMediator _drugProdutoMediator;
        public RelayCommand<Drug> CreateDrugCommand { get; set; }
        public CreateProductViewModel(IDrugProdutoMediator drugProdutoMediator)
        {            
            _drugProdutoMediator = drugProdutoMediator;
            CreateDrugCommand = new RelayCommand<Drug>(_drugProdutoMediator.CreateDrugFrom,CanExecuteCreateDrug);
        }        
        public bool CanExecuteCreateDrug(Drug drug)
        {
            return true;
        }
    }
}
