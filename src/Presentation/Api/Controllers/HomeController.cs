using DAL.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("[Controller]")]
    public class HomeController : Controller
    {        
        public IActionResult Index()
        {
            if (!GlobalConfiguration.IsFirstRun)
            {
                return Redirect("api/v1");
            }
            return RedirectToAction("Index","Setup");
            
        }
    }
}
