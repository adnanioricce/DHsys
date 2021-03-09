using Core.Entities.Catalog;
using Core.Interfaces;

namespace Web.Controllers.Catalog
{    
    public class ProductController : BaseController<Product>
    {
        public ProductController(IRepository<Product> _repository) : base(_repository)
        {
            
        }
        
    }    
}