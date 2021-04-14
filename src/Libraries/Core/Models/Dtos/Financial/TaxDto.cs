using System;
using System.Linq;
using Core.Entities.Financial;

namespace Core.Models.Dtos.Financial
{
    public class TaxDto : BaseEntityDto
    {        
        public string Name { get; set; }

        public decimal Percentage { get; set; }
    }
}