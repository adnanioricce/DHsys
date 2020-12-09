using GalaSoft.MvvmLight;

namespace Desktop.Models
{
    public class ProductCardModel : ViewModelBase
    {        
        private string _barCode = "bar";
        private string _code = "";
        private string _name = "";
        private string _description = "";
        private decimal _costPrice = 0.0m;
        private decimal _endCustomerPrice = 0.0m;
        private int _stockQuantity = 0;
        private string _frontImage = "";
        public string Barcode { get { return _barCode; } set { Set(ref _barCode, value); } }
        public string Code { get { return _code; } set { Set(ref _code, value); } }
        public string Name { get { return _name; } set { Set(ref _name, value); } }
        public string Description { get { return _description; } set { Set(ref _description, value); } }
        public decimal CostPrice { get { return _costPrice; } set { Set(ref _costPrice,value); } }
        public decimal EndCustomerPrice { get { return _endCustomerPrice; } set { Set(ref _endCustomerPrice, value); } }
        public int StockQuantity { get { return _stockQuantity; } set { Set(ref _stockQuantity, value); } }
        public string FrontImage { get { return _frontImage; } set { Set(ref _frontImage, value); } }

    }
}
