using Core.Entities.Catalog;
using Core.Entities.Stock;
using Core.Interfaces;
using Desktop.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;

namespace Desktop.ViewModels.Product
{
    public class CreateProductViewModel : ViewModelBase
    {        
        private readonly IDrugService _drugService;
        //private readonly BaseValidator<Drug> _validator;
        public CreateProductModel Model { get; set; } = new CreateProductModel();
        public ObservableCollection<ManufacturerModel> Manufacturers { get; set; } = new ObservableCollection<ManufacturerModel>();
        public ObservableCollection<string> Sections { get; set; } = new ObservableCollection<string>(new string[] {
            "Eticos",
            "Genericos",
            "Bonificados",
            "Varejo",
            "Perfumaria"
        });
        public RelayCommand<Drug> CreateDrugCommand { get; set; }
        public CreateProductViewModel(IDrugService drugService, IRepository<Manufacturer> manufactuerRepository)
        {
            _drugService = drugService;            
            CreateDrugCommand = new RelayCommand<Drug>(_drugService.CreateDrug,CanExecuteCreateDrug);
            var manufacturers = manufactuerRepository.Query()
                .Select(m => new ManufacturerModel { Id = m.Id, ManufacturerName = m.Name});
            foreach(var manufacturer in manufacturers)
            {
                Manufacturers.Add(manufacturer);
            }
        }        
        public bool CanExecuteCreateDrug(Drug drug)
        {            
            return true;
        }
    }
}
