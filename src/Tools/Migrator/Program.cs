using DAL.DbContexts;
using DAL.Extensions;
using System;

namespace Helper
{
    class Program
    {
        private static readonly string[] _commandList = new string[]
        {
            "migrate","add_migration","remove_migration","seed"
        };
        private static readonly string _helpMessage = @"
        options:
            migrate - run remaining database migrations for given npgsql connection string
            add_migration - Add a new migration for the Desktop and Api Projects
                parameters:                    
                    --migrationName -> the name of the migration
            remove_migration - removes a migration from the Desktop and Api projects 
            seed - run seed script on given npgsql connection string
        ";        
        
        static void Main(string[] args)
        {            
            if(args.Length == 0)
            {
                Console.WriteLine(_helpMessage);
            }
            for (int i = 0; i < args.Length; i++)
            {                                
                if(args[i] == "-h" || args[i] == "--help")
                {
                    Console.WriteLine(_helpMessage);
                }
                if (args.Length == (i + 1))
                {                    
                    return;
                }
                Handle(args[i].Substring(args[i].LastIndexOf("-") + 1), args[i + 1]);
            }
        }        
                
        public static void Handle(string option,string argument)
        {
            switch (option.ToLower())
            {
                case "migrate":
                    Migrator.Migrate(argument);
                    break;
                case "add_migration":
                    Migrator.AddMigration(argument, ContextType.Remote);
                    Migrator.AddMigration(argument, ContextType.Local);
                    break;
                case "remove_migration":
                    Migrator.DeleteMigration(ContextType.Remote);
                    Migrator.DeleteMigration(ContextType.Local);
                    break;
                case "seed":
                    Seeder.Seed(argument);
                    break;                
                default:
                    break;
            }
        }                
    }
    
}
