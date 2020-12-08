using DAL.DbContexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Migrator
{
    public class SeedCommand
    {
        public int Id { get; protected set; }
        public bool Finished { get; set; }
        private readonly string _connectionString;
        private readonly List<object> _chunk = new List<object>();
        public SeedCommand(int id, string connectionString, IEnumerable<object> chunk)
        {
            Id = id;
            _connectionString = connectionString;
            _chunk.AddRange(chunk);
        }
        public Task<int> Seed()
        {
            var contextFactory = new RemoteContextFactory();
            var context = contextFactory.CreateContext(_connectionString);
            try
            {
                if (!(_chunk?.Count == 0))
                {
                    Console.WriteLine("Seed task {0} starting", Id);
                    context.AddRange(_chunk);
                    var changes = context.SaveChanges();
                    Console.WriteLine("Work of task {0} finished, {1} changes writed", Id, changes);
                    Finished = true;
                    return Task.FromResult(changes);
                }
                return Task.FromResult(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:{0}", ex.ToString());
                Finished = true;
                return Task.FromResult(-1);
            }
        }
    }
}
