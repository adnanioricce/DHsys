using Core.Entities.Catalog;
using Core.Interfaces;
using Core.Interfaces.Catalog;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Desktop.ViewModels.Product
{
    public class UpdateProductViewModel : ViewModelBase
    {
        private readonly IDrugService _drugService;
        public RelayCommand<Drug> UpdateProductCommand { get; set; }
        public UpdateProductViewModel(IDrugService drugService)
        {
            _drugService = drugService;
            UpdateProductCommand = new RelayCommand<Drug>((drug) => _drugService.UpdateDrug(drug.Id,drug));
        }
    }
}
