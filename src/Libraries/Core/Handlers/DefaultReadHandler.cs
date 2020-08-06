using AutoMapper;
using Core.Commands.Default;
using Core.Entities;
using Core.Extensions;
using Core.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Handlers
{
    /// <summary>
    /// Default handler of read operations
    /// </summary>
    /// <typeparam name="TEntity">The entity type to be operated</typeparam>
    /// <typeparam name="TEntityResponse">The return type of the operation. May be a custom object, may be a dto of the entity</typeparam>
    public class DefaultReadHandler<TEntity,TEntityResponse> : IRequestHandler<DefaultReadRequest<TEntity,TEntityResponse>, TEntityResponse> where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        public DefaultReadHandler(IRepository<TEntity> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TEntityResponse> Handle(DefaultReadRequest<TEntity, TEntityResponse> request, CancellationToken cancellationToken)
        {
            return _mapper.Map<TEntityResponse>(await _repository.GetByAsync(request.Id));
        }
    }
}
