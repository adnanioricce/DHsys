using System;
using System.Collections.Generic;
using System.Text;

namespace Desktop.Models.POS
{
    public class TransactionItemModel
    {
        public decimal CustomerValue { get; set; }
        public string Price { get { return $"${CustomerValue}"; } }

    }
}
