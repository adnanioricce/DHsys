using System.Collections.Generic;

namespace Core.Models.Dbf
{
    public class RecordDiff
    {
        /// <summary>
        /// Get or set the index of the record
        /// </summary>
        public int RecordIndex { get; set; }
        /// <summary>
        /// Get or Set the list with the columns changed
        /// </summary>
        public List<RecordColumn> ColumsChanged { get; set; }        
        /// <summary>
        /// Get or set the Whole Record value
        /// </summary>
        public object RecordValue { get; set; }
        /// <summary>
        /// Get or Set if the RecordDiff is a new record 
        /// </summary>
        public bool IsNew { get; set; } = false;
    }
}