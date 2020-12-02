using Core.Entities.Stock;

namespace Core.ApplicationModels.Dtos.Financial
{
    public class ManufacturerDto : BeneficiaryDto 
    {        
        public string Cnpj { get; set; }
        
    }
}