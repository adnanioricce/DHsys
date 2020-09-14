using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using Api.Extensions;
using Application;
using Application.Extensions;
using DAL.DbContexts;
using DAL.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Npgsql;

namespace Api
{
    public class Startup : BaseStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {            
        }        

        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.AddControllers();
            services.AddGrpc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DH Api", Version = "v1" });
            });            
                                 
            services.AddMvc()
                .AddNewtonsoftJson(settings => {
                    settings.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    settings.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;                    
                });            
            services.AddDataStore(Configuration,opt => opt.UseNpgsql(Configuration.GetValue<string>("AppSettings:DatabaseSettings:ConnectionStrings:RemoteConnection")));
            services.AddTransient<DbContextResolver>(provider => key => {
                string option = key.ToLower();
                var contexts = provider.GetServices<BaseContext>();
                return option switch
                {
                    "remote" => contexts.FirstOrDefault(c => c is RemoteContext),
                    "local" => contexts.FirstOrDefault(c => c is LocalContext),
                    _ => contexts.FirstOrDefault(c => c is LocalContext)
                };
            });
            services.AddTransient<ConnectionResolver>(db => key => {
                return key switch
                {
                    //our local database
                    "local" => new SqliteConnection(Configuration.GetValue<string>("AppSettings:DatabaseSettings:ConnectionStrings:LocalConnection")),                                        
                    //a remote database to keep some changes
                    "remote" => new NpgsqlConnection(Configuration.GetValue<string>("AppSettings:DatabaseSettings:ConnectionStrings:RemoteConnection")),
                    _ => throw new KeyNotFoundException("there is no IDbConnection registered that match the given key"),
                };
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
