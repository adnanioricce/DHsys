using Core.Entities.Stock;

namespace Core.Models.Dtos.Financial
{
    public class ManufacturerDto : BeneficiaryDto 
    {        
        public string Cnpj { get; set; }
        
    }
}