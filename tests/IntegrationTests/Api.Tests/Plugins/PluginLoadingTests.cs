using Infrastructure.Plugins;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Api.Tests.Plugins
{
    public class PluginLoadingTests
    {
        [Fact]
        public void TryToLoadPluginByAssembly()
        {
            var configMock = new Mock<IConfiguration>();
            var hostEnvMock = new Mock<IWebHostEnvironment>();
            var plugins = PluginLoader.LoadPlugins("./PluginDLLs",configMock.Object,hostEnvMock.Object);
            var serviceCollection = new ServiceCollection();
            foreach (var plugin in plugins)
            {
                plugin.ConfigureServices(serviceCollection);
            }
            
        }
    }
}
