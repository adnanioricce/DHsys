using Core.Entities;
using Core.Entities.Catalog;
using Core.Entities.Financial;
using Core.Entities.Stock;
using DAL.DbContexts;
using DAL.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Migrator
{
    class Program
    {
        private static readonly string[] _commandList = new string[]
        {
            "migrate","seed"
        };
        private static readonly string _helpMessage = @"
        options:
            migrate - run remaining database migrations for given npgsql connection string                
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
                if (args.Length == (i + 1))
                {                    
                    return;
                }
                Handle(args[i].Substring(args[i].LastIndexOf("-") + 1), args[i + 1]);
            }
        }
        /// <summary>
        /// Applies all remaining sql migrations for the given connection
        /// </summary>
        /// <param name="connectionString">the connection string of the database to be migrated</param>
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
                case "migrate":
                    Migrate(argument);
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
