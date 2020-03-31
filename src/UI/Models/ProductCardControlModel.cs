using GalaSoft.MvvmLight;

namespace UI.Models
{
    public class ProductCardControlModel : ObservableObject
    {
        public string Barcode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal EndCustomerPrice { get; set; }
        public int StockQuantity { get; set; }
        public string FrontImage { get; set; }

    }
}
