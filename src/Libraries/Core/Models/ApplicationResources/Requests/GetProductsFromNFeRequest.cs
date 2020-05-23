using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.ApplicationResources.Requests
{
    public class GetProductsFromNFeRequest
    {
        public string NFeKey { get; set; }
        public string CNPJ { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
