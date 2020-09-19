using Application.Windows.Services.Catalog;
using Core.Interfaces.Catalog;
using DAL.Windows;
using DAL.Windows.Mappers;
using DAL.Windows.Repositories;
using Legacy.Interfaces.Catalog;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api.Windows
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<IDrugProdutoMediator, DrugProdutoMediator>();
            services.AddScoped(fac => {
                var context = new LegacyContext(Configuration.GetConnectionString("DefaultConnection"));
                return context;
            });
            services.AddScoped(typeof(ILegacyRepository<>), typeof(ProdutoRepository<>));
            services.AddSingleton(typeof(ILegacyDataMapper<,>), typeof(ProdutoMapper));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
