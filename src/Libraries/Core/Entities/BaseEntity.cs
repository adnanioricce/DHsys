using Microsoft.VisualBasic.CompilerServices;
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
        public virtual int Id { get; set; }
        /// <summary>
        /// Get or Set A unique string code for the entity. 
        /// used for better compability with legacy system and to handle CRUD operations
        /// </summary>
        /// <value></value>
        public virtual string UniqueCode { get; set; }
        /// <summary>
        /// Get or Set a flag indicating if this entity was deleted
        /// </summary>
        public virtual bool IsDeleted { get; set; }
        /// <summary>
        /// Get or Set when current entity was created
        /// </summary>
        public virtual DateTimeOffset CreatedAt { get; set; }
        /// <summary>
        /// Get or Set the last time this entity was updated
        /// </summary>
        public virtual DateTimeOffset LastUpdatedOn { get; set; } = DateTimeOffset.UtcNow;
       
    }
}
