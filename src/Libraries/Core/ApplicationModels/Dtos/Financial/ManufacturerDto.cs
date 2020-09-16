using System;
using System.Linq;
using Core.Entities.Stock;

namespace Core.ApplicationModels.Dtos.Financial
{
    public class ManufacturerDto
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }

        public static ManufacturerDto FromModel(Manufacturer model)
        {
            return new ManufacturerDto()
            {
                Cnpj = model.Cnpj, 
            }; 
        }

        public Manufacturer ToModel()
        {
            return new Manufacturer()
            {
                Cnpj = Cnpj, 
            }; 
        }
    }
}