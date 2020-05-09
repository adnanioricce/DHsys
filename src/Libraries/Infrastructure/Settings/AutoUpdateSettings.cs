namespace Infrastructure.Settings
{
    public class AutoUpdateSettings
    {
        public string UpdateFileUrl { get; set; }
        public string DsaPublicKey { get; set; }
        public string ReferenceAssembly { get; set; }
        public string SecurityMode { get; set; }
        public string AppIcon { get; set; }
        public bool ShouldUpdateSilently { get; set; }
    }
}
