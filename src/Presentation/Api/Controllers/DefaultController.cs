using Core.Entities;
using Core.Interfaces;

namespace Api.Controllers
{
    public class DefaultController<TEntity,TEntityDto> where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> _repository;
        public DefaultController()
        {
            
        }
    }
}