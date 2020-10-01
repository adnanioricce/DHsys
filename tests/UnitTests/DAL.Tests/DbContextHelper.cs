using DAL.DbContexts;
using DAL.Extensions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Tests
{
    public class DbContextHelper
    {
        public static BaseContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BaseContext>();
            optionsBuilder.UseSqlite(new SqliteConnection($"DataSource=:memory:"));
            var context = new BaseContext(optionsBuilder.Options);
            context.ApplyUpgrades();
            return context;
        }
    }
}
