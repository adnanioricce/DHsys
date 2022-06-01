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
    [Route("/")]
    public class HomeController : Controller
    {        
        [HttpGet]
        public IActionResult Index()
        {            
            return Redirect("api/v1");
            
        }
    }
}