using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DbContexts
{
    public class DbContextOptionsFactory
    {
        public DbContextOptionsBuilder CreateContextOptions(DbContextOptionsBuilder optionsBuilder,Action<DbContextOptionsBuilder> optionsBuilderAction)
        {
            optionsBuilder.UseLazyLoadingProxies();
            if (!(optionsBuilderAction is null))
            {
                optionsBuilderAction(optionsBuilder);
                return optionsBuilder;
            }            
            return optionsBuilder;
        }
    }
}
