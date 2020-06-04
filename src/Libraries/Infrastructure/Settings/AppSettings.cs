
namespace Infrastructure.Settings
{
    public class AppSettings
    {        
        public GitSettings GitSettings { get; set; }
        public DatabaseSettings DatabaseSettings { get; set; }
        public AutoUpdateSettings AutoUpdateSettings { get; set; }
    }
}
