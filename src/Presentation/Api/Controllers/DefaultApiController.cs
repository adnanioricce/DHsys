using AutoMapper;
using Core.Commands.Default;
using Core.Entities;
using Core.Extensions;
using Core.Interfaces;
using Core.Models.ApplicationResources;
using LibGit2Sharp;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultApiController<TEntity> : ControllerBase where TEntity : BaseEntity
    {
        private readonly IMediator _mediator;
        public DefaultApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create")]
        public virtual async Task<BaseResourceResponse> CreateAsync(TEntity entity)
        {
            var request = new DefaultCreateRequest<TEntity,BaseResourceResponse>
            {
                Entity = entity
            };
            var result = await _mediator.Send(request);
            return result;
        }
        [HttpGet("read")]
        public virtual async Task<BaseResourceResponse> GetAsync(object id)
        {
            var request = new DefaultReadRequest<TEntity, BaseResourceResponse<TEntity>>
            {
                Id = (int)id
            };
            var result = await _mediator.Send(request);
            return result;
        }
        [HttpPut("update")]
        public virtual async Task<BaseResourceResponse> UpdateAsync(object id, TEntity entity)
        {
            var request = new DefaultUpdateRequest<TEntity, BaseResourceResponse>
            {
                Id = id,
                Entity = entity
            };
            var result = await _mediator.Send(request);
            return result;
        }
        [HttpDelete("delete")]
        public virtual async Task<BaseResourceResponse> DeleteAsync(object id)
        {
            var request = new DefaultUpdateRequest<TEntity, BaseResourceResponse>
            {
                Id = id                
            };
            var result = await _mediator.Send(request);
            return result;
        }        
    }
}
