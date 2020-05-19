using System;
using System.Linq;

namespace Core.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// Get or Set integer Id of Entity.
        /// On database level, it's a primary key 
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
        /// <summary>
        /// Get or Set A unique string code for the product. 
        /// used for better compability with legacy system and to handle stock CRUD operations
        /// </summary>
        /// <value></value>
        public string UniqueCode { get; set; }
        /// <summary>
        /// Get or Set the last time this entity was updated
        /// </summary>
        public DateTimeOffset LastUpdatedOn { get; set; } = DateTimeOffset.UtcNow;
    }
}
