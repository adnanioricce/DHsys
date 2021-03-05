using System;
using System.Linq;
using Core.Entities.Payments;

namespace Core.ApplicationModels.Dtos.Payments
{
    public class PaymentMethodDto : BaseEntityDto
    {
        public string Name { get; set; }

        public bool AcceptsPartialPayments { get; set; }        
        
    }
}