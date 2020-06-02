using DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DbContexts
{
    public class LocalContext : BaseContext
    {
        //protected LocalContext() : base()
        //{

        //}
        public LocalContext(DbContextOptions<LocalContext> options) : base(options)
        {

        }
        //public LocalContext(DbContextOptions<LocalContext> options) : base(options)
        //{            
        //}

        
    }
}
