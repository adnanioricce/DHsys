using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Commands.Default
{
    public class DefaultDeleteRequest<TEntity> : IRequest where TEntity : BaseEntity
    {
        public object Id { get; set; }
    }
    public class DefaultDeleteRequest<TEntity,TResponse> : IRequest<TResponse> where TEntity : BaseEntity
    {
        public object Id { get; set; }
    }
}
