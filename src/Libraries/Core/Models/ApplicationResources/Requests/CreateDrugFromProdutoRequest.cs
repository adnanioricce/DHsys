using Core.Entities.LegacyScaffold;
using System.Collections.Generic;

namespace Core.Models.ApplicationResources.Requests
{
    public class CreateDrugFromProdutoRequest
    {
        public IEnumerable<Produto> CreatedProdutos { get; set; } = new List<Produto>();
    }
}
