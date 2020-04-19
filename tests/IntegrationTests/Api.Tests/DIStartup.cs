using Api.Tests.Seed;
using DAL;
using System;
using Tests.Lib.Extensions;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

namespace Api.Tests
{
    public class DIStartup : DependencyInjectionTestFramework
    {
        public DIStartup(IMessageSink messageSink) : base(messageSink)
        {
        }
        protected override void Configure(IServiceProvider provider)
        {
            var context = (MainContext)provider.GetService(typeof(MainContext));
            context.SeedDataForIntegrationTests(DrugSeed.GetDataForHttpGetMethods());            
        }
    }
}
