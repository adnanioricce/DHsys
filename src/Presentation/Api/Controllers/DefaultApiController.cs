using Core.Entities;
using Core.Interfaces;
using Core.Models.ApplicationResources;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DefaultApiController<TEntity,TEntityResponse> : ControllerBase where TEntity : BaseEntity where TEntityResponse : class
    {        
        protected readonly IRepository<TEntity> _repository;
        public DefaultApiController(IRepository<TEntity> repository)
        {            
            _repository = repository;
        }
        [HttpPost("create")]
        public virtual async Task<ActionResult<BaseResourceResponse>> CreateAsync(TEntity entity)
        {
            try
            {
                _repository.Add(entity);
                var result = await _repository.SaveChangesAsync();
                return Ok(BaseResourceResponse.GetDefaultSuccessResponseWithObject(result));
            }catch(Exception ex)
            {
                //TODO: log exception
                throw;
            } 
        }
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<BaseResourceResponse>> GetAsync([FromRoute]int id)
        {
            try
            {                
                var result = await _repository.GetByAsync(id);
                return Ok(BaseResourceResponse.GetDefaultSuccessResponseWithObject(result));
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }
        [HttpPut("{id}")]
        public virtual async Task<ActionResult<BaseResourceResponse>> UpdateAsync([FromRoute]int id, [FromBody]TEntity entity)
        {            
            try
            {
                _repository.Update(entity);
                var result = await _repository.SaveChangesAsync();
                return Ok(BaseResourceResponse.GetDefaultSuccessResponseWithObject(result));
            }
            catch(DbUpdateException ex)
            {
                throw ex;
            }            
        }
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult<BaseResourceResponse>> DeleteAsync(int id)
        {
            var entity = await _repository.GetByAsync(id);
            _repository.Delete(entity);
            _repository.SaveChanges();
            return Ok(BaseResourceResponse.DefaultSuccessResponse);
        }        
    }
}
