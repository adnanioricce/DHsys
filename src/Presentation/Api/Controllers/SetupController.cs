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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
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
            //quick fix?
            context.Database.Migrate();
            GlobalConfiguration.IsFirstRun = false;
            GlobalConfiguration.WriteFirstRunFile();
            return Ok();
        }
    }
}
