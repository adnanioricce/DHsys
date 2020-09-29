using System;
using System.Collections.Generic;
using System.Linq;
using Core.ApplicationModels.Dtos.Financial;
using Core.ApplicationModels.Dtos.Stock;
using Core.Entities;

namespace Core.ApplicationModels.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }
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