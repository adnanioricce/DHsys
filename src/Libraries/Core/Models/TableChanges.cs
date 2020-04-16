using System.Collections.Generic;

namespace Core.Models
{
    public class TableChanges<T> 
    {
        public IEnumerable<T> ChangedRows { get; set; }

    }
}
