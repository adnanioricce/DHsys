using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Entities;
using Core.Interfaces;
using Core.Models.ApplicationResources;
using FluentValidation;
using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    //[ApiVersion("1.0")]
    //[ODataRoutePrefix("[Controller]")]
    public class DefaultApiController<TEntity,TEntityDto> : ODataController where TEntity : BaseEntity where TEntityDto : class
    {        
        protected readonly IRepository<TEntity> _repository;
        protected readonly IValidator _validator;
        protected readonly IMapper _mapper;
        public DefaultApiController(IRepository<TEntity> repository, IMapper mapper,IValidator<TEntity> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
        
        [EnableQuery]        
        [Produces("application/json")]
        [HttpGet]
        public async Task<IQueryable<TEntityDto>> Query()
        {
            var entities = await _repository.Query()
                                    .Select(e => _mapper.Map<TEntity, TEntityDto>(e))
                                    .ToListAsync();
            return entities.AsQueryable();
        }
        [HttpPost("validate-create")]
        public async Task<IActionResult> Validate(TEntityDto dto)
        {
            var entity = _mapper.Map<TEntityDto, TEntity>(dto);
            var validationResult = await _validator.ValidateAsync(entity);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
            return Ok(validationResult);

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
                return Ok(BaseResourceResponse.GetDefaultSuccessResponseWithObject(_mapper.Map<TEntity,TEntityDto>(entity)));
            }catch(Exception ex)
            {
                Log.Error("Exception throwed at {className} for entity {entityName} when creating entity: Exception:{@exception}\n entity object:{@entity}", this.GetType().Name ,nameof(TEntity), ex, entity);
                return StatusCode(500, BaseResourceResponse.GetDefaultFailureResponseWithObject<TEntityDto>(_mapper.Map<TEntity,TEntityDto>(entity),string.Format("Sorry, a problem occured when trying to create a new entry for the given object ")));
            }
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BaseResourceResponse<object>), 200)]
        [ProducesResponseType(typeof(BaseResourceResponse), 404)]
        [ProducesResponseType(typeof(BaseResourceResponse), 500)]
        public virtual async Task<ActionResult<BaseResourceResponse>> GetAsync([FromRoute]int id)
        {
            try
            {
                var entity = await _repository.GetByAsync(id);
                if(entity == null)
                {
                    Log.Information("GetByAsync call with {idType} id {id} returned a null result",id.GetType().Name,id);
                    return NotFound(BaseResourceResponse.GetFailureResponseWithMessage($"entity with id {id} was not found"));
                }
                var entityDto = _mapper.Map<TEntity, TEntityDto>(entity);
                return Ok(BaseResourceResponse.GetDefaultSuccessResponseWithObject(entityDto));
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
        public virtual async Task<ActionResult<BaseResourceResponse>> UpdateAsync([FromRoute]int id, [FromBody]TEntityDto dto)
        {            
            try
            {
                var entity = _mapper.Map<TEntityDto, TEntity>(dto);
                _repository.Update(entity);
                var result = await _repository.SaveChangesAsync();
                var resultDto = _mapper.Map<TEntity, TEntityDto>(entity);
                return Ok(BaseResourceResponse.GetDefaultSuccessResponseWithObject(resultDto));
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
