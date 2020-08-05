using Core.Entities.Legacy;
using Core.Models.ApplicationResources.Responses;
using MediatR;
using System.Collections.Generic;

namespace Core.Models.ApplicationResources.Requests
{
    public class CreateDrugFromProdutoRequest : IRequest<CreateResponse>
    {
        public IEnumerable<Produto> CreatedProdutos { get; set; } = new List<Produto>();
    }
}
