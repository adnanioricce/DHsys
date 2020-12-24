using Core.Entities.Catalog;
using Core.Entities.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Tests.Seed
{
    public static class DrugSeed
    {
        public static IEnumerable<Product> GetDataForHttpGetMethods()
        {
            return new List<Product>
            {
                new Product
                {
                    Name = "Lixiana 10mg 2cp",
                    BarCode = "0987654321012",
                    RegistryCode = Guid.NewGuid().ToString(),                    
                    Ncm = "30003234124",                                      
                },                
            };
        }
        public static IEnumerable<Product> GetDrugForTransactions()
        {
            return new List<Product>
            {
                new Product
                {
                    Name = "Lixiana 10mg 2cp",
                    BarCode = "0987654321012",
                    RegistryCode = Guid.NewGuid().ToString(),
                    //TODO: Remove duplicated property                    
                    ICMS = 18,
                    MinimumStock = 1,                    
                    Ncm = "30003234124",                    
                }
            };
        }
    }
}
