using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public static class GlobalConfiguration
    {
        public static bool IsFirstRun { 
            get { return Convert.ToBoolean(Environment.GetEnvironmentVariable("IS_FIRST_RUN")); } 
            set { Environment.SetEnvironmentVariable("IS_FIRST_RUN", value.ToString()); }
        }        
    }
}
