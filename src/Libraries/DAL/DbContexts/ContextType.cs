using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DbContexts
{
    public enum ContextType
    {
        Local = 1,
        Remote = 2,
        Legacy = 0
    }
}
