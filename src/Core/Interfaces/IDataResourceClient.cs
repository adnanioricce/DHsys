using Core.Models.Resources.Requests;
using Core.Models.Resources.Responses;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDataResourceClient
    {
        Task<GetStockResourceResponse> GetExternalResource(GetStockResourceRequest getResourceRequest);
    }
}
