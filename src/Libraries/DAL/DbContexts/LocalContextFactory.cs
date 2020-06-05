﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DbContexts
{
    public class LocalContextFactory : IDesignTimeDbContextFactory<LocalContext>
    {
        public LocalContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LocalContext>();
            optionsBuilder.UseSqlite("Data Source=migration-placeholder.db");

            return new LocalContext(optionsBuilder.Options);
        }
    }
}