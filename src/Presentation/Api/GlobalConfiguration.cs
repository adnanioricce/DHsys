using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Logging;

namespace Api
{
    public static class GlobalConfiguration
    {
        public static bool IsFirstRun { 
            get { return Convert.ToBoolean(Environment.GetEnvironmentVariable("IS_FIRST_RUN")); } 
            set { Environment.SetEnvironmentVariable("IS_FIRST_RUN", value.ToString()); }
        }

        internal static void WriteFirstRunFile()
        {
            if(!File.Exists(nameof(GlobalConfiguration.IsFirstRun))){
                using var file = File.Create(nameof(GlobalConfiguration.IsFirstRun));                
            }
        }        
    }
}
