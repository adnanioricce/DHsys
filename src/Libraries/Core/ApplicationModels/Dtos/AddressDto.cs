using System.Collections.Generic;
using Core.ApplicationModels.Dtos.Financial;
using Core.ApplicationModels.Dtos.Stock;

namespace Core.ApplicationModels.Dtos
{
    public class AddressDto : BaseEntityDto
    {        
        public string FirstAddressLine { get; set; }

        public string SecondAddressLine { get; set; }

        public string Zipcode { get; set; }

        public string Addressnumber { get; set; }

        public string City { get; set; }

        public string AddressState { get; set; }

        public string District { get; set; }

        public ICollection<ClientDto> Clients { get; set; }

        public ICollection<ManufacturerDto> Manufacturer { get; set; }

        public ICollection<SupplierDto> Suppliers { get; set; }
       
    }
}