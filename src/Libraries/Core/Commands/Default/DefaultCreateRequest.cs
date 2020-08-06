using Core.Entities;
using Core.Models.ApplicationResources;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Commands.Default
{
    public class DefaultCreateRequest<TRequest> : IRequest where TRequest : BaseEntity 
    {
        public TRequest Entity { get; set; }
    }
    public class DefaultBulkCreateRequest<TRequest> : IRequest where TRequest : BaseEntity 
    {
        public ICollection<TRequest> Entities { get; set; } = new List<TRequest>();
    }
}
