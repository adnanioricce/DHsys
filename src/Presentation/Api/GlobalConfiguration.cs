using System;
using System.IO;

namespace Api
{
    public static class GlobalConfiguration
    {
        public static bool IsDockerContainer
        {
            get { return Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER",EnvironmentVariableTarget.Process)?.ToLower() == "true"; } 
        }
        public static string DhConnectionString
        {
            get { return Environment.GetEnvironmentVariable("DH_CONNECTION_STRING",EnvironmentVariableTarget.Process); }
        }
        public static bool IsFirstRun { 
            get { return Convert.ToBoolean(Environment.GetEnvironmentVariable("IS_FIRST_RUN")); } 
            set { Environment.SetEnvironmentVariable("IS_FIRST_RUN", value.ToString()); }
        }
        
        internal static void WriteFirstRunFile()
        {
            if(!File.Exists(nameof(GlobalConfiguration.IsFirstRun))){
                using var file = File.CreateText(nameof(GlobalConfiguration.IsFirstRun));
                file.Write(DhConnectionString);
            }
        }        
    }
}
