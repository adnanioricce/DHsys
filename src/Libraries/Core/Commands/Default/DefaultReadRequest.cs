using Core.Entities;
using Core.Models.ApplicationResources;
using MediatR;
using System;

namespace Core.Commands.Default
{
    public class DefaultReadRequest<TEntity,TResponse> : IRequest<TResponse> where TEntity : BaseEntity
    {
        public virtual object Id { get; set; }
        
    }
}
