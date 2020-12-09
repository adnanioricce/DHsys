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
        private readonly IProductService _drugService;
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
        public RelayCommand<Core.Entities.Catalog.Product> CreateDrugCommand { get; set; }
        public CreateProductViewModel(IProductService drugService, IRepository<Manufacturer> manufactuerRepository)
        {
            _drugService = drugService;            
            CreateDrugCommand = new RelayCommand<Core.Entities.Catalog.Product>(_drugService.CreateProduct, CanExecuteCreateProduct);
            var manufacturers = manufactuerRepository.Query()
                .Select(m => new ManufacturerModel { Id = m.Id, ManufacturerName = m.Name});
            foreach(var manufacturer in manufacturers)
            {
                Manufacturers.Add(manufacturer);
            }
        }        
        public bool CanExecuteCreateProduct(Core.Entities.Catalog.Product product)
        {            
            return true;
        }
    }
}
