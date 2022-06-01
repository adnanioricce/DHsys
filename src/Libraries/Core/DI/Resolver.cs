using System;

namespace Core.DI
{
    public static class Resolver
    {
        private static IServiceProvider _provider;
        public static void Initialize(IServiceProvider provider){
            _provider = provider;
        }
        public static T GetService<T>(){
            if(_provider is null)
                throw new InvalidOperationException("Resolver was not initialized");
            return (T)_provider.GetService(typeof(T));
        }
    }
}