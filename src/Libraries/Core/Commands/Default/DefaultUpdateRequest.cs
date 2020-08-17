using Core.Entities;
using MediatR;

namespace Core.Commands.Default
{
    public class DefaultUpdateRequest<TEntity> : IRequest where TEntity : BaseEntity 
    {
        public object Id { get; set; }
        public TEntity Entity { get; set; }
    }
    public class DefaultUpdateRequest<TEntity,TResponse> : IRequest<TResponse> where TEntity : BaseEntity
    {
        public object Id { get; set; }
        public TEntity Entity { get; set; }
    }
}
