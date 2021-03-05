using System;
using Core.ApplicationModels.Dtos.User;
using Core.Entities.Payments;

namespace Core.ApplicationModels.Dtos.Payments
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