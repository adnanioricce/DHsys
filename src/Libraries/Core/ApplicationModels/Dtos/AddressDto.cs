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

        public static AddressDto FromModel(Address model)
        {
            return new AddressDto()
            {
                FirstAddressLine = model.FirstAddressLine, 
                SecondAddressLine = model.SecondAddressLine, 
                Zipcode = model.Zipcode, 
                Addressnumber = model.Addressnumber, 
                City = model.City, 
                AddressState = model.AddressState, 
                District = model.District, 
                Clients = model.Clients.Select(c => ClientDto.FromModel(c)).ToList(), 
                Manufacturer = model.Manufacturer.Select(m => ManufacturerDto.FromModel(m)).ToList(), 
                Suppliers = model.Suppliers.Select(s => SupplierDto.FromModel(s)).ToList(), 
            }; 
        }

        public Address ToModel()
        {
            return new Address()
            {
                FirstAddressLine = FirstAddressLine, 
                SecondAddressLine = SecondAddressLine, 
                Zipcode = Zipcode, 
                Addressnumber = Addressnumber, 
                City = City, 
                AddressState = AddressState, 
                District = District, 
                Clients = Clients.Select(c => c.ToModel()).ToList(), 
                Manufacturer = Manufacturer.Select(m => m.ToModel()).ToList(), 
                Suppliers = Suppliers.Select(s => s.ToModel()).ToList(), 
            }; 
        }
    }
}