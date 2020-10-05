using DAL.DbContexts;
using DAL.Extensions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Lib
{
    public class DbContextHelper
    {
        public static BaseContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BaseContext>();
            optionsBuilder.UseSqlite(new SqliteConnection($"DataSource=:memory:"));
            var context = new BaseContext(optionsBuilder.Options);                        
            return context;
        }
    }
}
