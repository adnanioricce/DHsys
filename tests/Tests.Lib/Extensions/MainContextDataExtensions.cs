using DAL;

namespace Tests.Lib.Extensions
{
    public static class MainContextDataExtensions
    {
        public static void SeedDataForIntegrationTests(this MainContext context,params object[] entities)
        {
            context.AddRange(entities);
            context.SaveChanges();
        }
    }
}
