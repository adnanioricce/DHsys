using DAL.DbContexts;
using DAL.Extensions;
using System;

namespace Migrator
{
    class Program
    {
        private static readonly string _helpMessage = @"
        options:
            --connectionString - npgsql connection string to be migrated            
        ";
        static void Main(string[] args)
        {
            args = new string[] { "--connectionString", "User ID=postgres;Password=postgres;Host=localhost;Port=2424;Database=dhsysdb_dev;Pooling=true;" };
            if(args.Length == 0)
            {
                Console.WriteLine(_helpMessage);    
            }
            for (int i = 0; i < args.Length; i++)
            {                
                if (args[i].StartsWith("--"))
                {
                    if(args.Length < (i + 1))
                    {
                        Console.WriteLine($"{args[i]} option has no argument");
                        return;
                    }
                    Handle(args[i].Substring(args[i].LastIndexOf("-") + 1),args[i + 1]);
                }
            }
        }
        public static void Migrate(string connectionString)
        {
            var remoteContextFactory = new RemoteContextFactory();
            var remoteContext = remoteContextFactory.CreateContext(connectionString);
            try
            {
                remoteContext.ApplyUpgrades();
            }
            catch(Exception ex)
            {                
                Console.WriteLine($"Migrations failed with the following error:{ex}");
            }
        }
        public static void Handle(string option,string argument)
        {
            switch (option.ToLower())
            {
                case "connectionstring":
                    Migrate(argument);
                    break;
                default:
                    break;
            }
        }        
    }
}
