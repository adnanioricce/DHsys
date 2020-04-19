using Microsoft.AspNetCore.Mvc;
namespace Api.Models
{
    /// <summary>
    /// Model class to handle query parameters in routes
    /// </summary>
    [BindProperties(SupportsGet = true)]    
    public class CatalogQuery
    {        
        public int? Id { get; set; }        
        public string Barcode { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Get or Set Which parameter should have priority on query result
        /// </summary>
        public Parameter ParameterPriority { get; set;  }        
    }
    public enum Parameter
    {
        All = 0,
        Id = 1,
        Barcode = 2,
        Name = 3
        
    }

}
