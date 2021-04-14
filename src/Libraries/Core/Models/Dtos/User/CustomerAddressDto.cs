using System;
using Core.Entities.User;

namespace Core.Models.Dtos.User
{
    public class CustomerAddressDto : BaseEntityDto
    {
        public int CustomerId { get; set; }

        public CustomerDto Customer { get; set; }

        public int AddressId { get; set; }

        public AddressDto Address { get; set; }

        public AddressType Type { get; set; }
    }
}