using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DbContexts
{
    public class BaseContextFactory : IDesignTimeDbContextFactory<BaseContext>
    {
        public BaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BaseContext>();
            optionsBuilder.UseSqlite("Data Source=migration-placeholder.db");

            return new BaseContext(optionsBuilder.Options);
        }
    }
}
