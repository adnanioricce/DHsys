using Core.Entities.Catalog;
using Core.Interfaces;
using Core.Models;
using Infrastructure.Interfaces;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Desktop.Services
{
    public class Scanner : IApplicationScanner
    {
        private readonly IProductService _drugService;
        private StringBuilder _barcode = new StringBuilder();
        public event EventHandler BarcodeScanned;  
        
        public Scanner(IProductService drugService)
        {
            _drugService = drugService;
        }
        public Task<BaseResult<Product>> OnBarcodeScan(object sender,KeyEventArgs e)
        {
            if (44 == (int)e.Key) e.Handled = true;
            _barcode.Append(e.Key);
            if(_barcode.Length == 12)
            {
                var drug = _drugService.SearchProductByBarCode(_barcode.ToString());
                _barcode.Clear();                
            }
            throw new NotImplementedException();            
        }

        public Task<BaseResult<Product>> GetProductByBarcodeAsync(string barcode)
        {
            throw new NotImplementedException();
        }
    }
}
