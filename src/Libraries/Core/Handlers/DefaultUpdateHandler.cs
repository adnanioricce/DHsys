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
    public class DefaultUpdateHandler<TEntity> : IRequestHandler<DefaultUpdateRequest<TEntity, BaseResourceResponse>, BaseResourceResponse> where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> _repository;       
        public DefaultUpdateHandler(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public virtual async Task<BaseResourceResponse> Handle(DefaultUpdateRequest<TEntity, BaseResourceResponse> request, CancellationToken cancellationToken)
        {
            var _entity = await _repository.GetByAsync(request.Id);
            _repository.Update(request.Entity);
            var result = await _repository.SaveChangesAsync();
            if(result < 0)
            {
                return BaseResourceResponse.DefaultFailureResponse;
            }
            return new BaseResourceResponse<TEntity>("entity was updated successfully", _entity);
        }
    }
}
