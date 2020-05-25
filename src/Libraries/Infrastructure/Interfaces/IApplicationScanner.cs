using Core.Entities.Catalog;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    /// <summary>
    /// Handles operations related with the scanner and the application services
    /// </summary>
    public interface IApplicationScanner
    {
        public event EventHandler BarcodeScanned;
        Task<BaseResult<Drug>> GetDrugByBarcodeAsync(string barcode);
    }
}
