using System;
using Core.Models.Dtos.User;
using Core.Entities.Payments;

namespace Core.Models.Dtos.Payments
{
    public class PaymentDto : BaseEntityDto
    {
        public CustomerDto Customer { get; set; }

        public PaymentMethodDto Method { get; set; }

        public PaymentStatus Status { get; set; }

        public decimal ReceivedValue { get; set; }

        public decimal NeededValue { get; set; }

        public decimal Change { get; set; }
    }
}