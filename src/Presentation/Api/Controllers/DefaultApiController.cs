using Core.Entities;
using Core.Interfaces;
using Core.Models.ApplicationResources;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
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
        [ProducesResponseType(typeof(BaseResourceResponse<int>), 200)]
        [ProducesResponseType(typeof(BaseResourceResponse<object>), 500)]
        public virtual async Task<ActionResult<BaseResourceResponse>> CreateAsync(TEntity entity)
        {
            try
            {
                _repository.Add(entity);
                var result = await _repository.SaveChangesAsync();
                return Ok(BaseResourceResponse.GetDefaultSuccessResponseWithObject(result));
            }catch(Exception ex)
            {
                Log.Error("Exception throwed at {className} for entity {entityName} when creating entity: Exception:{@exception}\n entity object:{@entity}", this.GetType().Name ,nameof(TEntity), ex, entity);
                return StatusCode(500, BaseResourceResponse.GetDefaultFailureResponseWithObject<TEntity>(entity,string.Format("Sorry, a problem occured when trying to create a new entry for the given object ")));
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BaseResourceResponse<object>), 200)]
        [ProducesResponseType(typeof(BaseResourceResponse<object>), 500)]
        public virtual async Task<ActionResult<BaseResourceResponse>> GetAsync([FromRoute]int id)
        {
            try
            {                
                var result = await _repository.GetByAsync(id);
                return Ok(BaseResourceResponse.GetDefaultSuccessResponseWithObject(result));
            }
            catch(Exception ex)
            {
                Log.Error("Exception throwed at {className} of entity {entityName} when creating entity: Exception:{@ex}",this.GetType().Name,nameof(TEntity), ex);
                return StatusCode(500, BaseResourceResponse.GetFailureResponseWithMessage(string.Format("Sorry, a problem occured when trying to search for the entity with id {0}", id)));
            }            
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BaseResourceResponse<object>), 200)]
        [ProducesResponseType(typeof(BaseResourceResponse<object>), 500)]
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
                Log.Error("Exception throwed at {className} of entity {entityName} when creating entity: Exception:{@exception}", this.GetType().Name, nameof(TEntity), ex);
                return StatusCode(500, BaseResourceResponse.GetFailureResponseWithMessage(string.Format("Sorry, a problem occured when trying to update the entity with id {0}", id)));
            }
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(BaseResourceResponse), 200)]
        [ProducesResponseType(typeof(BaseResourceResponse<object>), 500)]
        public virtual async Task<ActionResult<BaseResourceResponse>> DeleteAsync(int id)
        {
            var entity = await _repository.GetByAsync(id);
            try
            {
                _repository.Delete(entity);
                _repository.SaveChanges();
                return Ok(BaseResourceResponse.DefaultSuccessResponse);
            }
            catch (Exception ex)
            {
                Log.Error("Exception throwed at {className} of entity {entityName} when trying to delete entity. Exception:{@exception} \n entity object:{@entity}", this.GetType().Name, nameof(TEntity), ex, entity);
                return StatusCode(500, BaseResourceResponse.GetDefaultFailureResponseWithObject<TEntity>(entity,string.Format("Sorry, a problem occured when trying to delete the entity with id {0}", id)));
            }            
        }        
    }
}
