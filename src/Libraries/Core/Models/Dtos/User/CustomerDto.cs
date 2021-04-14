using System.Collections.Generic;

namespace Core.Models.Dtos.User
{
    public class CustomerDto : BaseEntityDto
    {
        public ICollection<CustomerAddressDto> Addresses { get; set; }

        public string CPF { get; set; }
        public string Name { get; set; }

    }
}