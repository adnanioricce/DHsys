using System;
using System.IO;

namespace Api
{
    public static class GlobalConfiguration
    {
        public static bool IsDockerContainer
            => Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER",EnvironmentVariableTarget.Process)?.ToLower() == "true";
        public static string DhConnectionString
            => Environment.GetEnvironmentVariable("DH_CONNECTION_STRING",EnvironmentVariableTarget.Process);
        public static bool IsFirstRun { 
            get => Convert.ToBoolean(Environment.GetEnvironmentVariable("IS_FIRST_RUN")); 
            set => Environment.SetEnvironmentVariable("IS_FIRST_RUN", value.ToString());
        }
        public static string GetDatabaseUrl(){
            return Environment.GetEnvironmentVariable("DATABASE_URL");
        }
        public static string GetIdentityDatabaseUrl(){
            return Environment.GetEnvironmentVariable("IDENTITY_DB_URL");
        }         
    }
}
