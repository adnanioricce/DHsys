using Core.Interfaces;
using Core.Models.Resources.Requests;
using Core.Models.Resources.Responses;
using System.Threading.Tasks;

namespace Core.Services
{
    public class SupplierDataResourceClient : IDataResourceClient
    {
        private readonly string _baseUrl;
        public SupplierDataResourceClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public Task<GetStockResourceResponse> GetExternalResource(GetStockResourceRequest getResourceRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}
