using System.Collections.Generic;
using Core.Models.Dbf;

namespace Core.Models.ApplicationResources.Requests
{
    public class SyncDatabaseRequest
    {
        /// <summary>
        /// Get or set the name of the table in which records come from
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// Get or set dictionary with index and changed/new records
        /// </summary>
        public Dictionary<int, RecordDiff> RecordDiffs { get; set; } = new Dictionary<int, RecordDiff>();
    }
}
