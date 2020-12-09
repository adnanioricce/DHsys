using Core.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Desktop.Models;
using System.Threading;
using Core.Entities.Catalog;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Windows.Threading;
using System.Collections.Generic;

namespace Desktop.ViewModels.Product
{
    public class ProductListViewModel : ViewModelBase
    {        
        private readonly IProductService _drugService;
        private readonly IRepository<Core.Entities.Catalog.Product> _repository;
        private List<Core.Entities.Catalog.Product> _backCollection = new List<Core.Entities.Catalog.Product>();       
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
                Dispatcher.CurrentDispatcher.InvokeAsync(async () => await GetProductsBySearchPattern(_searchPattern));
            } }
        private bool _searchBoxEnabled = false;
        public bool SearchBoxEnabled { get { return _searchBoxEnabled; } set { Set(ref _searchBoxEnabled, value); }}
        public RelayCommand LoadDataCommand { get; set; }
        public RelayCommand<string> GetDrugByCodeCommand { get; set; }
        public RelayCommand<string> GetDrugByBarcodeCommand { get; set; }        
        public RelayCommand<string> GetDrugBySearchPatternCommand { get; set; }
        
        public ProductListViewModel(IProductService drugService,IRepository<Core.Entities.Catalog.Product> repository)
        {                        
            _drugService = drugService;
            GetDrugByCodeCommand = new RelayCommand<string>(async (parameter) => await GetProductByCode(parameter));
            GetDrugBySearchPatternCommand = new RelayCommand<string>(async (parameter) => await GetProductsBySearchPattern(parameter));
            GetDrugByBarcodeCommand = new RelayCommand<string>(async (parameter) => await GetProductByBarcode(parameter));
            LoadDataCommand = new RelayCommand(() => ThreadPool.QueueUserWorkItem(async (state) => await LoadData()));
            _repository = repository;
        }
        private ProductCardModel ToCardModel(Core.Entities.Catalog.Product drug)
        {
            return new ProductCardModel
            {
                Code = drug.UniqueCode,
                Barcode = drug.BarCode,
                Description = drug.Description,
                EndCustomerPrice = drug.EndCustomerPrice.HasValue ? drug.EndCustomerPrice.Value : 0.00m,
                Name = drug.Name,
                FrontImage = (drug.GetThumbnailImage() is null) ? "../../Resources/placeholder.png" : drug.GetThumbnailImage().Media.SourceUrl,
                StockQuantity = drug.QuantityInStock.HasValue ? drug.QuantityInStock.Value : 0,
                CostPrice = drug.CostPrice,
            };
        }
        public async Task LoadData()
        {
            SearchBoxEnabled = true;
            var products = _repository.Query()
                                      .ToListAsync();
            _backCollection.AddRange(await products);
            var collection = ToObservable(_backCollection);
            DrugCollection = collection;
            SearchBoxEnabled = false;
        }

        public async Task GetProductByCode(string parameter)
        {
            var drug = await _drugService.GetProductByUniqueCodeAsync(parameter);
            var productModel = ToCardModel(drug);
            if (!DrugCollection.Contains(productModel))
            {
                DrugCollection.Add(productModel);
            }
        }        
        public async Task GetProductsBySearchPattern(string pattern)
        {            
            var products = _backCollection.Where(d => d.Name.Contains(pattern));
            var collection = ToObservable(products);
            DrugCollection = collection;
        }      
        public async Task GetProductByBarcode(string barcode)
        {
            var drug = await _drugService.SearchProductByBarCodeAsync(barcode);
            DrugCollection.Clear();
            DrugCollection.Add(ToCardModel(drug));
        }
        private ObservableCollection<ProductCardModel> ToObservable(IEnumerable<Core.Entities.Catalog.Product> products)
        {
            var collection = new ObservableCollection<ProductCardModel>();
            foreach (var product in products)
            {
                collection.Add(ToCardModel(product));
            }
            return collection;
        }
    }
}
