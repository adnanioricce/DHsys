using Core.Interfaces;
using Core.Models.ApplicationResources;
using Core.Models.ApplicationResources.Requests;
using Core.Models.ApplicationResources.Responses;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Handlers.Catalog.Product
{
    public class CreateDrugFromProdutoHandler : IRequestHandler<CreateDrugFromProdutoRequest, BaseResourceResponse>
    {
        private readonly IDrugService _drugService;
        public CreateDrugFromProdutoHandler(IDrugService drugService)
        {
            _drugService = drugService;
        }
        public virtual async Task<BaseResourceResponse> Handle(CreateDrugFromProdutoRequest request, CancellationToken cancellationToken)
        {
            var result = await _drugService.CreateDrugsAsync(request.CreatedProdutos);
            if(result <= 0)
            {
                return BaseResourceResponse.DefaultFailureResponse;
            }
            return BaseResourceResponse.DefaultSuccessResponse;
        }
    }
}
