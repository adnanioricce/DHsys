using Core.Commands.Default;
using Core.Entities;
using Core.Extensions;
using Core.Interfaces;
using Core.Models.ApplicationResources;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Handlers
{
    public class DefaultDeleteHandler<TEntity,TResponse> : IRequestHandler<DefaultDeleteRequest<TEntity, TResponse>, TResponse> where TEntity : BaseEntity where TResponse : BaseResourceResponse
    {
        private readonly IRepository<TEntity> _repository;
        public DefaultDeleteHandler(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public virtual async Task<TResponse> Handle(DefaultDeleteRequest<TEntity, TResponse> request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByAsync(request.Id);
            if(entity is null)
            {
                return (TResponse)new BaseResourceResponse("couldn't delete entity, because there is no entity with given id");
            }
            return (TResponse)new BaseResourceResponse("entity was deleted successfully",true);
        }
    }
}
