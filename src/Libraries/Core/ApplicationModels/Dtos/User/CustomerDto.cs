using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Entities.User;

namespace Core.ApplicationModels.Dtos.User
{
    public class CustomerDto : BaseEntityDto
    {
        public ICollection<CustomerAddressDto> Addresses { get; set; }

        public string CPF { get; set; }
        public string Name { get; set; }

    }
}