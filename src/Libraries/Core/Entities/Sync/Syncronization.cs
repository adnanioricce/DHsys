using System;

namespace Core.Entities.Sync
{
    public class Syncronization : BaseEntity
    {
        /// <summary>
        /// Get or set from which database(ie:from a specific remote db)
        /// </summary>
        public string UpdatedFrom { get; set; }
        /// <summary>
        /// Get or set the last time this syncronization was created
        /// </summary>
        public DateTimeOffset LastSyncronization { get; set; }
    }
}
