using Core.Entities;
using Core.Entities.Catalog;
using Core.Entities.Financial;
using Core.Entities.Stock;
using DAL.DbContexts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Helper
{
    public class Seeder
    {
        private static readonly List<SeedCommand> _seedCommands = new List<SeedCommand>();
        /// <summary>
        /// Seeds some relevants tables with data to be used as demonstration purposes
        /// </summary>
        /// <param name="connectionString">the connection string of the database to be seeded</param>
        public static void Seed(string connectionString)
        {
            var watch = new Stopwatch();
            watch.Start();
            Seed<Category>("./DHsysData/categories.json", connectionString);
            Seed<Product>("./DHsysData/products.json", connectionString);
            while (_seedCommands.Any(c => !c.Finished))
            {
                _seedCommands.RemoveAll(command => command.Finished);
            }
            //Theses depend on the previous seed
            Seed<StockEntry>("./DHsysData/stock.json", connectionString);
            Seed<POSOrder>("./DHsysData/orders.json", connectionString);
            while (_seedCommands.Any(c => !c.Finished))
            {
                _seedCommands.RemoveAll(command => command.Finished);
            }
            watch.Stop();
            Console.WriteLine("all process take {0} to execute", watch.Elapsed);
        }
        /// <summary>
        /// Group the json file entries in fractions of a max of 512 entries(counting from the highest node)
        /// </summary>
        /// <typeparam name="T">The entity type to be parsed from json</typeparam>
        /// <param name="jsonPath">The path to the json file</param>
        /// <returns>a <see cref="IEnumerable{T}"/> of grouped <see cref="T"/></returns>
        public static IEnumerable<T[]> GetDataChunked<T>(string jsonPath) where T : BaseEntity
        {
            var items = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(jsonPath));
            var chunkSize = (int)MathF.Round((items.Count * 0.1f), MidpointRounding.AwayFromZero);
            if (chunkSize > 512)
            {
                chunkSize = 512;
            }
            return items.Select((item, index) => new { Item = item, Index = index })
                                    .GroupBy(i => i.Index / chunkSize, v => v.Item)
                                    .Select(chunk => chunk.ToArray());
        }
        /// <summary>
        /// Seeds the json data on the given connection string
        /// </summary>
        /// <typeparam name="T">the entity type to be parsed from the json file</typeparam>
        /// <param name="jsonPath">the json file</param>
        /// <param name="connectionString"></param>
        public static void Seed<T>(string jsonPath, string connectionString) where T : BaseEntity
        {
            if (!ThreadPool.SetMaxThreads(Environment.ProcessorCount / 2, 32))
            {
                Console.WriteLine("Couldn't set max number of threads");
            }
            var remoteContextFactory = new RemoteContextFactory();
            foreach (var item in GetDataChunked<T>(jsonPath))
            {
                var command = new SeedCommand(_seedCommands.Count + 1, connectionString, item);
                _seedCommands.Add(command);
                ThreadPool.QueueUserWorkItem(SeedCommand, command);
            }
            void SeedCommand(object state)
            {
                var command = (SeedCommand)state;
                command.Seed();
            }
        }
    }
}
