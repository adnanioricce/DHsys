using System;
using System.Collections.Generic;
using System.Text;

namespace Legacy.Models.Dbf
{
    public enum DiffOperation
    {
        Modified,
        New,
        Unchanged,
        Deleted
    }
}
