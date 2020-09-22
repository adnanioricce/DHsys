using Core.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Desktop.Models;
using System.Threading;

namespace Desktop.ViewModels.Product
{
    public class ProductListViewModel : ViewModelBase
    {        
        private readonly IDrugService _drugService;        
        private ObservableCollection<ProductCardModel> drugCollection = new ObservableCollection<ProductCardModel>();        
        public ObservableCollection<ProductCardModel> DrugCollection { get { return drugCollection; } 
            set 
            {   
                if (drugCollection == value) return;
                Set(ref drugCollection, value);
            } 
        }      
        private string _searchPattern = "";
        public string SearchPattern { get { return _searchPattern; } set 
            {
                if (this._searchPattern == value) return;
                Set(ref _searchPattern, value.ToUpper());
                ThreadPool.QueueUserWorkItem(async (parameter) => await ExecuteGetProductsBySearchPattern((string)parameter), _searchPattern);
            } }
        public RelayCommand<string> GetDrugByCodeCommand { get; set; }
        public RelayCommand<string> GetDrugByBarcodeCommand { get; set; }        
        public RelayCommand<string> GetDrugBySearchPatternCommand { get; set; }
        
        public ProductListViewModel(IDrugService drugService)
        {            
            GetDrugByCodeCommand = new RelayCommand<string>(async (parameter) => await ExecuteGetProductByCode(parameter));
            GetDrugBySearchPatternCommand = new RelayCommand<string>(async (parameter) => await ExecuteGetProductsBySearchPattern(parameter));
            GetDrugByBarcodeCommand = new RelayCommand<string>(async (parameter) => await ExecuteGetProductByBarcode(parameter));
            DrugCollection.Add(new ProductCardModel
            {
                Barcode = "1234567788123213",
                Code = "123456",
                Description = "description",
                EndCustomerPrice = 19.99m,
                StockQuantity = 1,
                FrontImage = "",
                Name = "Ibuprofeno"
            });
            _drugService = drugService;
        }               
        public async Task ExecuteGetProductByCode(string parameter)
        {
            var drug = await _drugService.GetDrugByUniqueCodeAsync(parameter);
            var productModel = new ProductCardModel
            {
                Code = drug.UniqueCode,
                Barcode = drug.BarCode,
                Description = drug.Description,
                EndCustomerPrice = drug.EndCustomerPrice.HasValue ? drug.EndCustomerPrice.Value : 0.00m,
                Name = drug.Name,
                FrontImage = "../../Resources/placeholder.png",
                StockQuantity = drug.QuantityInStock.HasValue ? drug.QuantityInStock.Value : 0,
                CostPrice = drug.CostPrice,                
            };
            if (!DrugCollection.Contains(productModel))
            {
                DrugCollection.Add(productModel);
            }
        }        
        public async Task ExecuteGetProductsBySearchPattern(string pattern)
        {
            //TODO:Insecure code, throws exception when just user type            
            var drugs = await _drugService.SearchDrugsByNameAsync(pattern);

            foreach (var drug in drugs)
            {                
                DrugCollection.Add(new ProductCardModel
                {
                    Code = drug.BarCode,
                    Barcode = drug.BarCode,
                    Description = drug.Description,
                    CostPrice = drug.CostPrice,
                    EndCustomerPrice = drug.EndCustomerPrice.HasValue ? drug.EndCustomerPrice.Value : 0.00m,
                    Name = drug.Name,
                    FrontImage = "../../Resources/placeholder.png",
                    StockQuantity = drug.QuantityInStock.HasValue ? drug.QuantityInStock.Value : 0
                });
            }                          
        }      
        public async Task ExecuteGetProductByBarcode(string barcode)
        {
            var drug = await _drugService.SearchDrugByBarCodeAsync(barcode);
            DrugCollection.Clear();
            DrugCollection.Add(new ProductCardModel
            {
                Code = drug.UniqueCode,
                Barcode = drug.BarCode,
                Description = drug.Description,
                CostPrice = drug.CostPrice,
                EndCustomerPrice = drug.EndCustomerPrice.HasValue ? drug.EndCustomerPrice.Value : 0,
                Name = drug.Name,
                FrontImage = "../../Resources/placeholder.png",
                StockQuantity = drug.QuantityInStock.HasValue ? drug.QuantityInStock.Value : 0
            });
        }
    }
}
