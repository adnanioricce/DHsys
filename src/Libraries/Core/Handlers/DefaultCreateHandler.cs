using Core.Commands.Default;
using Core.Entities;
using Core.Interfaces;
using Core.Models.ApplicationResources;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Handlers
{
    //TODO:Switch to one class for operation (create,read,update and delete)
    /// <summary>
    /// Default handler for CRUD operations
    /// </summary>
    /// <typeparam name="TEntity">The entity on which run the operations</typeparam>
    public class DefaultCreateHandler<TEntity> : IRequestHandler<DefaultCreateRequest<TEntity>>,
                                                 IRequestHandler<DefaultCreateRequest<TEntity,BaseResourceResponse>, BaseResourceResponse>,
                                                 IRequestHandler<DefaultBulkCreateRequest<TEntity,BaseResourceResponse>, BaseResourceResponse> where TEntity : BaseEntity 
    {
        private readonly IRepository<TEntity> _repository;
        public DefaultCreateHandler(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task<Unit> Handle(DefaultCreateRequest<TEntity> request, CancellationToken cancellationToken)
        {
            _repository.Add(request.Entity);
            await _repository.SaveChangesAsync();
            return Unit.Value;
        }

        public virtual async Task<BaseResourceResponse> Handle(DefaultCreateRequest<TEntity, BaseResourceResponse> request, CancellationToken cancellationToken)
        {
            _repository.Add(request.Entity);
            var result = await _repository.SaveChangesAsync();
            if(result < 0)
            {
                return BaseResourceResponse.DefaultFailureResponse;
            }
            return new BaseResourceResponse<TEntity>("entity was created successfully", request.Entity);
        }

        public virtual async Task<BaseResourceResponse> Handle(DefaultBulkCreateRequest<TEntity,BaseResourceResponse> request, CancellationToken cancellationToken)
        {
            _repository.AddRange(request.Entities);
            var result = await _repository.SaveChangesAsync();
            if(result < 0)
            {
                return BaseResourceResponse.DefaultFailureResponse;
            }
            return new BaseResourceResponse<ICollection<TEntity>>(string.Format("{0} were created with success", result),request.Entities);
        }
    }
}
