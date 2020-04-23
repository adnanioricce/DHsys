using GalaSoft.MvvmLight;

namespace UI.Models
{
    public class ProductCardModel : ViewModelBase
    {
        private string _barCode = "bar";
        public string Barcode { get { return _barCode; } set { Set(ref _barCode, value); } }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal CostPrice { get; set; }
        public decimal EndCustomerPrice { get; set; }
        public int StockQuantity { get; set; }
        public string FrontImage { get; set; }

    }
}
