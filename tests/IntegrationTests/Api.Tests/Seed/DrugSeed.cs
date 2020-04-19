using Core.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Tests.Seed
{
    public static class DrugSeed
    {
        public static IEnumerable<Drug> GetDataForHttpGetMethods()
        {
            return new List<Drug>
            {
                new Drug
                {
                    DrugName = "Dipirona 10mg 2cp",
                    BarCode = "0987654321012",
                    DrugCost = 4.67m,
                    Ncm = "30003234124"                   
                }
            };
        }
    }
}
