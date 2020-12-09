using Core.Entities.Catalog;
using Core.Interfaces;
using Core.Interfaces.Catalog;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Desktop.ViewModels.Product
{
    public class UpdateProductViewModel : ViewModelBase
    {
        private readonly IProductService _productService;
        public RelayCommand<Core.Entities.Catalog.Product> UpdateProductCommand { get; set; }
        public UpdateProductViewModel(IProductService productService)
        {
            _productService = productService;
            UpdateProductCommand = new RelayCommand<Core.Entities.Catalog.Product>((product) => _productService.UpdateProduct(product.Id,product));
        }
    }
}
