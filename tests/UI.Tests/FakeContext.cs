using DAL;
using Microsoft.EntityFrameworkCore;

namespace Core.Tests
{
    public class FakeContext : MainContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "testDb");
        }
    }
}
