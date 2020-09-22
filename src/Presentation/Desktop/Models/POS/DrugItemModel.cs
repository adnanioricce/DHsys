using System;

namespace Desktop.Models.POS
{
    public class DrugItemModel : GalaSoft.MvvmLight.ObservableObject
    {
        public int Id { get; set; }
        public string UniqueCode { get; set; }
        public string Barcode { get; set; }
        public string Classification { get; set; }
        public decimal EndCustomerPrice { get; set; }
        public string Price { get { return $"${EndCustomerPrice}"; } }
        public string Name { get; set; }
        public Uri ImageSource { get; set; }
    }
}
