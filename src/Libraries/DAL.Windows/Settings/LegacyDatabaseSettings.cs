namespace Infrastructure.Windows.Settings
{
    public class LegacyDatabaseSettings
    {
        public LegacyDatabaseSettings()
        {
            
        }
        public LegacyDatabaseSettings(string provider,string dataSource,string extendedProperties,string userID,string password)
        {
            Provider = provider;
            DataSource = dataSource;
            ExtendedProperties = extendedProperties;
            UserID = userID;
            Password = password;
        }
        public string Provider { get; set; }
        public string DataSource { get; set; }
        public string ExtendedProperties { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public override string ToString()
        {
            return $"Provider={Provider};Data Source={DataSource};Extended Properties={ExtendedProperties};User ID={UserID};Password={Password};";
        }
    }
}