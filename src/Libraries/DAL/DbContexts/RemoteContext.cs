using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
