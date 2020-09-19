
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Tests.Lib.Extensions
{
    public static class ApiControllerTestsExtensions
    {
        public static void AddControllerTestSetup(this IServiceCollection services,TestRequest requestData)
        {            
            //TODO:            
        }
    }
    public class TestRequest
    {
        public string Path { get; set; }
        public object Entity { get; set; }
        public (string,object) RouteParam  { get; set; }
        public object BodyData { get; set; }
        public bool UseBody { get; set; }
    }
}
