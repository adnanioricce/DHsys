namespace Core.Entities.Financial
{
    public class Beneficiary : BaseEntity
    {        
        /// <summary>
        /// Get or set the beneficiary name
        /// </summary>
        public string Name { get; set; }
        public int AddressId { get; set; }
        /// <summary>
        /// Get or Set the address of this beneficiary
        /// </summary>
        public virtual Address Address { get; set; }       
    }
}
