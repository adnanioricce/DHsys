using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using DAL.DbContexts;
using DAL.Extensions;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Api.Controllers
{
    [Route("[Controller]")]
    public class SetupController : Controller
    {        
        private readonly IWritableOptions<ConnectionStrings> _connectionStrings;
        private readonly IServiceProvider _serviceProvider;
        public SetupController(IWritableOptions<ConnectionStrings> connectionStrings,IServiceProvider serviceProvider)
        {            
            _connectionStrings = connectionStrings;
            _serviceProvider = serviceProvider;
        }        
        public ActionResult Index()
        {
            if (!GlobalConfiguration.IsFirstRun)
            {
                return Redirect("api/v1");
            }
            return View();
            
        }        
                
        [HttpPost]
        [Route("Migrate")]
        public ActionResult Migrate(DbConnectionSetup model)
        {
            string connectionString = $"User ID={model.UserId};Password={model.Password};Host={model.Hostname};Port={model.Port};Database={model.Database};Pooling=true;";
            _connectionStrings.Update((connStr) => connStr.RemoteConnection = connectionString);
            var context = (RemoteContext)_serviceProvider.GetService(typeof(RemoteContext));
            try
            {
                context.ApplyUpgrades();
                GlobalConfiguration.IsFirstRun = false;
                return View();
            }
            catch
            {
                throw;
            }
        }
    }
}
