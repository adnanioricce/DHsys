using System;
using System.Collections.Generic;
using System.Text;

namespace Desktop.Models.POS
{
    public class TransactionItemModel
    {
        public int ProductId { get; set; }
        public DrugItemModel Drug { get; set; }
        public decimal CustomerValue { get; set; }
        public string Price { get { return $"${CustomerValue}"; } }
        public int Quantity { get; set; }
    }
}
