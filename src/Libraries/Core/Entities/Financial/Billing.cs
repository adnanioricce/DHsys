using System;

namespace Core.Entities.Financial
{
    public class Billing : BaseEntity
    {        
        public int BeneficiaryId { get; set; }
        public string BeneficiaryName { get; set; }
        public PersonDocumentType PersonType { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public bool IsPaid { get; set; }        
    }
}
