using Core.Entities.Legacy;
using System.Collections.Generic;

namespace Core.Models.ApplicationResources.Requests
{
    public class CreateDrugFromProdutoRequest
    {
        public IEnumerable<Produto> CreatedProdutos { get; set; } = new List<Produto>();
    }
}
