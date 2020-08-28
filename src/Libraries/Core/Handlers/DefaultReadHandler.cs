using AutoMapper;
using Core.ApplicationModels;
using Core.Commands.Default;
using Core.Entities;
using Core.Extensions;
using Core.Interfaces;
using Core.Models.ApplicationResources;
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
    public class DefaultReadHandler<TEntity,TEntityResponse> : IGetByIdHandler
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        public DefaultReadHandler(IRepository<TEntity> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }                

        public async Task<IBaseResult> Handle(DefaultReadRequest request, CancellationToken cancellationToken)
        {
            return (IBaseResult)_mapper.Map<TEntityResponse>(await _repository.GetByAsync(request.Id));
        }
    }
}