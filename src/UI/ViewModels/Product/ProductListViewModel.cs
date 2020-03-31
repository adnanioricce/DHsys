using Core.Entities.LegacyScaffold;
using Core.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using UI.Models;

namespace UI.ViewModels.Product
{
    public class ProductListViewModel : ViewModelBase
    {
        private readonly ILegacyRepository<Produto> _produtoRepository;
        public ObservableCollection<ProductCardControlModel> ProdutoCollection { get; set; } = new ObservableCollection<ProductCardControlModel>();
        public RelayCommand<string> GetProductByCodeCommand { get; set; }
        public RelayCommand<string> GetProductsBySearchPatternCommand { get; set; }
        public ProductListViewModel(ILegacyRepository<Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
            GetProductByCodeCommand = new RelayCommand<string>(ExecuteGetProductByCode);
            GetProductsBySearchPatternCommand = new RelayCommand<string>(ExecuteGetProductsBySearchPattern);
            ProdutoCollection.Add(new ProductCardControlModel
            {
                Barcode = "1234567788123213",
                Code = "123456",
                Description = "description",
                EndCustomerPrice = 19.99m,
                StockQuantity = 1,
                FrontImage = "",
                Name = "Ibuprofeno"
            });
        }
        public void ExecuteGetProductByCode(string parameter)
        {
            var produto = _produtoRepository.GetById((string)parameter);
            var productModel = new ProductCardControlModel
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
            var produtos = _produtoRepository.MultipleFromRawSqlQuery($@"SELECT * FROM PRODUTO.DBF 
            WHERE prdesc LIKE '%{pattern}%' 
            OR prbarra LIKE '%{pattern}%'
            OR prprinci LIKE '%{pattern}%'
            OR prcodi LIKE '%{pattern}%'
            OR prbarra LIKE '%{pattern}%'");
            foreach (var produto in produtos)
            {                
                ProdutoCollection.Add(new ProductCardControlModel
                {
                    Code = produto.Prcodi,
                    Barcode = produto.Prbarra,
                    Description = produto.Prdesc,
                    EndCustomerPrice = decimal.TryParse(produto.Prfinal.ToString(),out var price) ? price : 0.00m,
                    Name = produto.Prdesc,
                    FrontImage = "../../Resources/placeholder.png",
                    StockQuantity = int.TryParse(produto.Prestq.ToString(),out var result) ? result : 0                    
                });
            }
        }        
    }
}
