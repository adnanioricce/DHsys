using Core.Entities;
using Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Handlers
{
    //TODO:Switch to one class for operation (create,read,update and delete)
    /// <summary>
    /// Default handler for CRUD operations
    /// </summary>
    /// <typeparam name="TEntity">The entity on which run the operations</typeparam>
    public class DefaultHandler<TEntity> : IRequestHandler<DefaultCreateRequest<TEntity>> where TEntity : BaseEntity 
    {
        private readonly IRepository<TEntity> _repository;
        public DefaultHandler(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DefaultCreateRequest<TEntity> request, CancellationToken cancellationToken)
        {
            _repository.Add(request.Entity);
            await _repository.SaveChangesAsync();
            return Unit.Value;
        }                
    }
}
