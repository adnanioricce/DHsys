using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using DAL.DbContexts;
using DAL.Extensions;
using Infrastructure.Logging;
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
            return View(new DbConnectionSetup());
            
        }        
                
        [HttpPost]        
        public ActionResult Index(DbConnectionSetup model)
        {
            if (!GlobalConfiguration.IsFirstRun)
            {
                return Redirect("api/v1");
            }
            _connectionStrings.Update((connStr) => connStr.RemoteConnection = model.ToString());
            var context = (RemoteContext)_serviceProvider.GetService(typeof(BaseContext));
            try
            {
                context.ApplyUpgrades();
                GlobalConfiguration.IsFirstRun = false;
                GlobalConfiguration.WriteFirstRunFile();
                AppLogger.Log.Information("Migrations applied successfully");
                return Redirect("api/v1");
            }
            catch(Exception ex)
            {
                AppLogger.Log.Error("Failed to apply migrations to the database, given exception was throw: @ex", ex);
                //TODO:Create a view error to use instead of simply throwing a whole exception to the user.                
                throw ex;
            }
        }
    }
}
