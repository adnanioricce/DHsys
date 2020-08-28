using Microsoft.EntityFrameworkCore;

namespace DAL.DbContexts
{
    public class RemoteContext : BaseContext
    {
        public RemoteContext(DbContextOptions<RemoteContext> options) : base(options)
        {
        }
        
    }
}
