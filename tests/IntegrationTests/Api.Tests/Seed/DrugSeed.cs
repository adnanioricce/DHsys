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
        public static IEnumerable<Drug> GetDataForHttpGetMethods()
        {
            return new List<Drug>
            {
                new Drug
                {
                    Name = "Lixiana 10mg 2cp",
                    BarCode = "0987654321012",
                    CostPrice = 4.67m,
                    Ncm = "30003234124",
                    ProductSuppliers = new List<ProductSupplier>{
                        new ProductSupplier{
                            Supplier = new Supplier{
                                Name = "MainSupplier"                                
                            },
                            Product = new Product{
                                
                            }
                        }
                    },                    
                },                
            };
        }
        public static IEnumerable<Drug> GetDrugForTransactions()
        {
            return new List<Drug>
            {
                new Drug
                {
                    Name = "Lixiana 10mg 2cp",
                    BarCode = "0987654321012",
                    //TODO: Remove duplicated property
                    CostPrice = 4.67m,
                    EndCustomerPrice = 12.99m,
                    QuantityInStock = 4,
                    ICMS = 18,
                    MinimumStock = 1,                    
                    Ncm = "30003234124",
                    ProductSuppliers = new List<ProductSupplier>{
                        new ProductSupplier{
                            Supplier = new Supplier{
                                Name = "MainSupplier"
                            },
                            Product = new Product{

                            }
                        }
                    }
                }
            };
        }
    }
}
