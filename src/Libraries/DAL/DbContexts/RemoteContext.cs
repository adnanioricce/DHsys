using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DAL.DbContexts
{
    public class RemoteContext : BaseContext
    {
        public RemoteContext(DbContextOptions<RemoteContext> options) : base(options)
        {
        }
        
    }
}
