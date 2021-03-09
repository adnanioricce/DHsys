using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BaseController<TEntity> : Controller
    {
        protected readonly IRepository<TEntity> _repository;        
                
        protected BaseController(IRepository<TEntity> repository)
        {
            _repository = repository;            
        }
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            var entity = await _repository.GetByAsync(id);
            return View(entity);
        }
    }
}