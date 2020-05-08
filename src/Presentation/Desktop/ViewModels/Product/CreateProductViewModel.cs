using Core.Entities.Catalog;
using Core.Entities.Stock;
using Core.Interfaces;
using Core.Interfaces.Catalog;
using Desktop.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Desktop.ViewModels.Product
{
    public class CreateProductViewModel : ViewModelBase
    {        
        private readonly IDrugProdutoMediator _drugProdutoMediator;
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
        public CreateProductViewModel(IDrugProdutoMediator drugProdutoMediator,IRepository<Manufacturer> manufactuerRepository)
        {            
            _drugProdutoMediator = drugProdutoMediator;
            CreateDrugCommand = new RelayCommand<Drug>(_drugProdutoMediator.CreateDrugFrom,CanExecuteCreateDrug);
            var manufacturers = manufactuerRepository.Query()
                .Select(m => new ManufacturerModel { Id = m.Id, ManufacturerName = m.ManufacturerName });
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
