using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.User
{
    public class CustomerAddress : BaseEntity
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public AddressType Type { get; set; }
    }
    public enum AddressType 
    {
        Billing
    }
}
