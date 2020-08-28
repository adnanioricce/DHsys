using Core.Entities.Legacy;
using Core.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Threading;
using Desktop.Models;
using System.IO;

namespace Desktop.ViewModels.Product
{
    public class ProductListViewModel : ViewModelBase
    {
        private Task _legacyWorkerThread;
        private readonly ILegacyRepository<Produto> _produtoRepository;
        private readonly IDrugService _drugService;
        private ObservableCollection<ProductCardModel> produtoCollection = new ObservableCollection<ProductCardModel>();        
        public ObservableCollection<ProductCardModel> ProdutoCollection { get { return produtoCollection; } set 
            {   if (produtoCollection == value) return;
                Set(ref produtoCollection, value);
            } 
        }      
        private string _searchPattern = "";
        public string SearchPattern { get { return _searchPattern; } set 
            {
                if (this._searchPattern == value) return;
                Set(ref _searchPattern, value.ToUpper());
                ExecuteGetProductsBySearchPattern(_searchPattern);
            } }
        public RelayCommand<string> GetProductByCodeCommand { get; set; }
        public RelayCommand<string> GetProductByBarcodeCommand { get; set; }        
        public RelayCommand<string> GetProductsBySearchPatternCommand { get; set; }
        
        public ProductListViewModel(ILegacyRepository<Produto> produtoRepository,IDrugService drugService)
        {
            _produtoRepository = produtoRepository;
            GetProductByCodeCommand = new RelayCommand<string>(ExecuteGetProductByCode);
            GetProductsBySearchPatternCommand = new RelayCommand<string>(ExecuteGetProductsBySearchPattern);
            GetProductByBarcodeCommand = new RelayCommand<string>(ExecuteGetProductByBarcode);
            ProdutoCollection.Add(new ProductCardModel
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
        public void ExecuteGetProductByCode(string parameter)
        {
            var produto = _produtoRepository.GetById((string)parameter);
            var productModel = new ProductCardModel
            {
                Code = produto.Prcodi,
                Barcode = produto.Prbarra,
                Description = produto.Prdesc,
                EndCustomerPrice = decimal.TryParse(produto.Prfinal.ToString(), out var price) ? price : 0.00m,
                Name = produto.Prdesc,
                FrontImage = "../../Resources/placeholder.png",
                StockQuantity = int.TryParse(produto.Prestq.ToString(), out var result) ? result : 0
            };
            if (!ProdutoCollection.Contains(productModel))
            {
                ProdutoCollection.Add(productModel);
            }
        }        
        public void ExecuteGetProductsBySearchPattern(string pattern)
        {
            //TODO:Insecure code, throws exception when just user type 
            if (!_legacyWorkerThread.IsCompleted) return;
            var task = new Task(() =>
            {
                var produtos = _produtoRepository.MultipleFromRawSqlQuery($@"SELECT * FROM PRODUTO.DBF 
                WHERE prdesc LIKE '%{pattern}%' 
                OR prbarra LIKE '%{pattern}%'
                OR prprinci LIKE '%{pattern}%'
                OR prcodi LIKE '%{pattern}%'");
                foreach (var produto in produtos)
                {
                    System.Windows.Application.Current.Dispatcher.Invoke(() =>
                    ProdutoCollection.Add(new ProductCardModel
                    {
                        Code = produto.Prcodi,
                        Barcode = produto.Prbarra,
                        Description = produto.Prdesc,
                        CostPrice = decimal.TryParse(produto.Prfabr.ToString(), out var costPrice) ? costPrice : 0.00m,
                        EndCustomerPrice = decimal.TryParse(produto.Prfinal.ToString(), out var price) ? price : 0.00m,
                        Name = produto.Prdesc,
                        FrontImage = "../../Resources/placeholder.png",
                        StockQuantity = int.TryParse(produto.Prestq.ToString(), out var result) ? result : 0
                    }));
                }
            });
            _legacyWorkerThread = task;
            task.Start();            
        }      
        public void ExecuteGetProductByBarcode(string barcode)
        {
            var drug = _drugService.SearchDrugByBarCode(barcode);
            ProdutoCollection.Clear();
            ProdutoCollection.Add(new ProductCardModel
            {
                Code = drug.UniqueCode,
                Barcode = drug.BarCode,
                Description = drug.Description,
                CostPrice = drug.CostPrice,
                EndCustomerPrice = drug.EndCustomerPrice.HasValue ? drug.EndCustomerPrice.Value : 0,
                Name = drug.DrugName,
                FrontImage = "../../Resources/placeholder.png",
                StockQuantity = drug.QuantityInStock.HasValue ? drug.QuantityInStock.Value : 0
            });
        }
    }
}
