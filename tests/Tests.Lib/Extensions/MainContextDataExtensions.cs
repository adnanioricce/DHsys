using DAL;
using Microsoft.EntityFrameworkCore;

namespace Tests.Lib.Extensions
{
    public static class MainContextDataExtensions
    {
        public static void SeedDataForIntegrationTests(this DbContext context,params object[] entities)
        {
            context.AddRange(entities);
            context.SaveChanges();
        }
    }
}
