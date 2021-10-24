namespace Infrastructure.Plugins
{
    public interface IPluginInitializerFactory
    {
        ConfigureServices GetConfigureServicesFactory();
        ConfigureApplication GetConfigureApplicationFactory();
        CreatePluginInitialization GetPluginInitializationFactory();
    }
}
