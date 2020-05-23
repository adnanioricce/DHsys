using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;
using Api.Extensions;
using Application;
using Application.Services;
using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
using Core.Interfaces;
using Core.Mappers;
using DAL;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Npgsql;

namespace Api
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

            string localConnString = Configuration.GetConnectionString("SqliteConnection");
            string remoteConnString = Configuration.GetConnectionString("RemoteConnection");
            services.AddControllers();
            services.AddGrpc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.AddTransient<IDbSynchronizer, DbSynchronizer>();
            services.AddDbContext<DbContext, MainContext>(
                opt => 
                {
                    opt.UseSqlite(localConnString)
                      .EnableDetailedErrors();
                    opt.UseLazyLoadingProxies();
                });
            services.AddScoped<MainContext>();
            services.Configure<LegacyDatabaseSettings>(Configuration.GetSection(nameof(LegacyDatabaseSettings)));
            services.Configure<GitSettings>(Configuration.GetSection(nameof(GitSettings)));
            services.AddScoped(typeof(LegacyContext<>));
            services.AddScoped(typeof(ILegacyRepository<>), typeof(DbfRepository<>));
            services.AddTransient<ILegacyDataMapper<Drug,Produto>,ProdutoMapper>();           
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IDrugService, DrugService>();
            services.AddMvc()
                .AddNewtonsoftJson(settings => {
                    settings.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    settings.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
            var legacySettings = Configuration.GetSection(nameof(LegacyDatabaseSettings)).Get<LegacyDatabaseSettings>();
            services.AddTransient<ConnectionResolver>(db => key =>  {
                return key switch
                {
                    //our local database
                    "local" => new SqliteConnection(localConnString),
                    //a legacy shared database from which source changes in real world environment
                    "source" => new OleDbConnection(legacySettings.ToString()),
                    //a remote database to keep some changes
                    "remote" => new NpgsqlConnection(remoteConnString),
                    _ => throw new KeyNotFoundException("there is no IDbConnection registered that match the given key"),
                };
                // new SqliteConnection(connString)    
            });       
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.BuildDatabase(env);
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;

            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();                                
            });
            
        }
    }
}
