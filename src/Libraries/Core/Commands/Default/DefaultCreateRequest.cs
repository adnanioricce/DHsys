using Core.Entities;
using Core.Models.ApplicationResources;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Commands.Default
{
    public class DefaultCreateRequest<TEntity> : IRequest where TEntity : BaseEntity 
    {
        public TEntity Entity { get; set; }
    }
    public class DefaultCreateRequest<TEntity,TResponse> : IRequest<TResponse> where TEntity : BaseEntity where TResponse : BaseResourceResponse
    {
        public TEntity Entity { get; set; }
    }    
    public class DefaultBulkCreateRequest<TEntity,TResponse> : IRequest<TResponse> where TEntity : BaseEntity
    {
        public ICollection<TEntity> Entities { get; set; } = new List<TEntity>();
    }
}
