using System;
using System.Linq;
using Core.Entities.Financial;

namespace Core.ApplicationModels.Dtos.Financial
{
    public class TaxDto : BaseEntityDto
    {        
        public string Name { get; set; }

        public decimal Percentage { get; set; }
    }
}