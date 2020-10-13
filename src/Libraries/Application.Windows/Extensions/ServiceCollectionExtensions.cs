using Application.Windows.Services.Sync;
using Core.Interfaces;
using Infrastructure.Windows.Interfaces;
using Legacy.Interfaces.Sync;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Windows.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWindowsApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ILegacyDbSynchronizer, LegacyDbSynchronizer>();
            services.AddTransient<ISyncQueryBuilder, SyncQueryBuilder>();
        }
    }
}
