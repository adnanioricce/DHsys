using Core.ApplicationModels;
using Core.Entities;
using Core.Models.ApplicationResources;
using MediatR;
using System;

namespace Core.Commands.Default
{
    public class DefaultReadRequest : IRequest<IBaseResult> 
    {
        public virtual int Id { get; set; }
    }
    public class DefaultReadRequest<TResponse> : IRequest<TResponse>
    {
        public virtual object Id { get; set; }
    }
    //public class DefaultReadRequest : IRequest<BaseResourceResponse>
    //{
    //    public virtual object Id { get; set; }
    //}
    //public class DefaultReadRequest : IRequest
    //{
    //    public virtual object Id { get; set; }
    //}
}
