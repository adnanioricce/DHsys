using System;
using Core.Entities;
using Core.Entities.Financial;

namespace Core.Models.Dtos.Financial
{
    public class BillingDto : BaseEntityDto
    {
        public int BeneficiaryId { get; set; }
        public string BeneficiaryName { get; set; }

        public PersonDocumentType PersonType { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal Price { get; set; }

        public decimal? Discount { get; set; }

        public bool IsPaid { get; set; }

        public static BillingDto FromModel(Billing model)
        {
            return new BillingDto()
            {                
                BeneficiaryName = model.BeneficiaryName, 
                PersonType = model.PersonType, 
                EndDate = model.EndDate, 
                Price = model.Price, 
                Discount = model.Discount, 
                IsPaid = model.IsPaid, 
            }; 
        }

        public Billing ToModel()
        {
            return new Billing()
            {                
                BeneficiaryName = BeneficiaryName, 
                PersonType = PersonType, 
                EndDate = EndDate, 
                Price = Price, 
                Discount = Discount, 
                IsPaid = IsPaid, 
            }; 
        }
    }
}