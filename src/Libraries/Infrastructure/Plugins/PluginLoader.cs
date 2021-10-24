using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Plugins
{
    public class PluginLoader
    {
        private CompositionContainer _container;
        private IEnumerable<Assembly> _pluginAssemblies;
        private PluginLoader(CompositionContainer compositionContainer,IEnumerable<Assembly> pluginAssemblies)
        {
            _container = compositionContainer;
            _pluginAssemblies = pluginAssemblies;
        }
        public void ComposeOn(object @hostObject)
        {
            _container.ComposeParts(hostObject);
        }
        public IEnumerable<Assembly> GetPluginAssemblies() => _pluginAssemblies;
        public CompositionContainer GetCompositionContainer() => _container;
        public static PluginLoader Create(Assembly hostAssembly,params Assembly[] pluginAssemblies)
        {
            var aggregateCatalog = new AggregateCatalog();
            aggregateCatalog.Catalogs.Add(new AssemblyCatalog(hostAssembly));            
            var catalogs = pluginAssemblies
                .Select(assembly => new AssemblyCatalog(assembly))
                .ToList();
            catalogs.ForEach(cat => aggregateCatalog.Catalogs.Add(cat));
            var container = new CompositionContainer(aggregateCatalog);
            return new PluginLoader(container,pluginAssemblies);
        }
        public static PluginLoader Create(Assembly hostAssembly,params string[] dllFiles)
            => Create(hostAssembly,dllFiles.Select(f => Assembly.LoadFrom(f)).ToArray());
    }
}
