using Microsoft.EntityFrameworkCore;

namespace DAL.DbContexts
{
    public class LocalContext : BaseContext
    {        
        public LocalContext(DbContextOptions<LocalContext> options) : base(options)
        {

        }        
    }
}
