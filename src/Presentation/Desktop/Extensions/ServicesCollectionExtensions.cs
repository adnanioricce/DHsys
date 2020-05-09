using Application.Services;
using Application.Services.Catalog;
using Application.Services.Sync;
using Core.Interfaces;
using Core.Interfaces.Catalog;
using Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Desktop.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IDrugProdutoMediator, DrugProdutoMediator>();
            services.AddTransient<IDrugService, DrugService>();
            services.AddTransient<IProdutoService, ProdutoService>();            
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IBillingService, BillingService>();
            services.AddTransient<IDbSynchronizer, DbSynchronizer>();
            services.AddTransient<ISyncQueryBuilder, SyncQueryBuilder>();
        }        
    }
}
