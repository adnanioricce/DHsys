using System;
using System.Linq;
using Core.Entities.Payments;

namespace Core.Models.Dtos.Payments
{
    public class PaymentMethodDto : BaseEntityDto
    {
        public string Name { get; set; }

        public bool AcceptsPartialPayments { get; set; }        
        
    }
}