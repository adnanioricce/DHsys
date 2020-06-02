using Core.Entities.Catalog;
using System.Collections.Generic;
namespace Core.Entities.Financial
{
    public class Transaction : BaseEntity
    {                
        public decimal TransactionTotal { get; set; }
        public virtual ICollection<TransactionItem> Items { get; set; }        
    }
}