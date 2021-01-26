using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Entities;
using Core.Interfaces;
using Core.Models.ApplicationResources;
using Core.Validations;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
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
    public class DefaultApiController<TEntity,TEntityDto> : ODataController where TEntity : BaseEntity where TEntityDto : class
    {        
        protected readonly IRepository<TEntity> _repository;
        protected readonly IValidator _validator;
        protected readonly IMapper _mapper;
        public DefaultApiController(IRepository<TEntity> repository, IMapper mapper,BaseValidator<TEntity> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
        
        [EnableQuery(PageSize = 25)]        
        [Produces("application/json")]
        [HttpGet("query")]
        public IQueryable Query()
        {
            return _repository.Query();
        }
        [HttpPost("validate-create")]
        [ProducesDefaultResponseType(typeof(ValidationResult))]
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
        [Produces("application/json")]
        [ProducesResponseType(typeof(BaseResourceResponse<int>), 200)]
        [ProducesResponseType(typeof(BaseResourceResponse<object>), 500)]
        public virtual async Task<ActionResult<BaseResourceResponse>> CreateAsync(TEntityDto entityDto)
        {
            var entity = _mapper.Map<TEntityDto, TEntity>(entityDto);
            try
            {
                _repository.Add(entity);
                var result = await _repository.SaveChangesAsync();
                if(result < 0) 
                {
                    return StatusCode(500, BaseResourceResponse.GetDefaultFailureResponseWithObject<TEntityDto>(_mapper.Map<TEntity, TEntityDto>(entity), string.Format("Sorry, a problem occured when trying to create a new entry for the given object ")));
                }
                return Ok(BaseResourceResponse.GetDefaultSuccessResponseWithObject(_mapper.Map<TEntity,TEntityDto>(entity)));
            }
            catch(Exception ex)
            {
                Log.Error("Exception throwed at {className} for entity {entityName} when creating entity: Exception:{@exception}\n entity object:{@entity}", this.GetType().Name ,nameof(TEntity), ex, entity);
                return StatusCode(500, BaseResourceResponse.GetDefaultFailureResponseWithObject<TEntityDto>(_mapper.Map<TEntity,TEntityDto>(entity),string.Format("Sorry, a problem occured when trying to create a new entry for the given object ")));
            }
        }
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BaseResourceResponse<object>), 200)]
        [ProducesResponseType(typeof(BaseResourceResponse), 404)]
        [ProducesResponseType(typeof(BaseResourceResponse), 500)]
        public virtual async Task<ActionResult<BaseResourceResponse>> GetAsync([FromRoute]int id)
        {
            var entity = await _repository.Query().Where(e => e.Id == id).FirstOrDefaultAsync();
            if (entity == null)
            {
                Log.Information("GetByAsync call with {idType} id {id} returned a null result", id.GetType().Name, id);
                return NotFound(BaseResourceResponse.GetFailureResponseWithMessage($"entity with id {id} was not found"));
            }
            try
            {
                Log.Information("Mapping...");
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
        [Produces("application/json")]
        [ProducesResponseType(typeof(BaseResourceResponse<object>), 200)]
        [ProducesResponseType(typeof(BaseResourceResponse<object>), 500)]
        public virtual async Task<ActionResult<BaseResourceResponse>> UpdateAsync([FromRoute]int id, [FromBody]TEntityDto dto)
        {
            var existing = await _repository.GetByAsync(id);
            if (existing is null)
            {
                Log.Information("Tried to retrieve a entity that don't exist for entity {entityName}. The given id was:{id}", typeof(TEntity).Name, id);
            }
            var updated = _mapper.Map<TEntityDto, TEntity>(dto);
            _mapper.Map(updated, existing);
            _repository.Update(existing);
            try
            {                                
                var result = await _repository.SaveChangesAsync();
                var resultDto = _mapper.Map<TEntity, TEntityDto>(existing);
                return Ok(BaseResourceResponse.GetDefaultSuccessResponseWithObject(resultDto));
            }
            catch(DbUpdateException ex)
            {
                Log.Error("Exception throwed at {className} of entity {entityName} when creating entity: Exception:{@exception}", this.GetType().Name, nameof(TEntity), ex);
                return StatusCode(500, BaseResourceResponse.GetFailureResponseWithMessage(string.Format("Sorry, a problem occured when trying to update the entity with id {0}", id)));
            }
        }
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BaseResourceResponse), 200)]
        [ProducesResponseType(typeof(BaseResourceResponse<object>), 500)]
        public virtual async Task<ActionResult<BaseResourceResponse>> DeleteAsync(int id)
        {
            var entity = await _repository.GetByAsync(id);
            if(entity is null)
            {
                Log.Information("GetByAsync call with {idType} id {id} returned a null result", id.GetType().Name, id);
                return NotFound(BaseResourceResponse.GetFailureResponseWithMessage($"entity with id {id} was not found"));
            }
            try
            {
                _repository.Delete(entity);
                _repository.SaveChanges();
                return Ok(BaseResourceResponse.DefaultSuccessResponse);
            }
            catch (DbUpdateException ex)
            {
                Log.Error("Exception throwed at {className} of entity {entityName} when trying to delete entity. Exception:{@exception} \n entity object:{@entity}", this.GetType().Name, nameof(TEntity), ex, entity);
                return StatusCode(500, BaseResourceResponse.GetDefaultFailureResponseWithObject<TEntityDto>(_mapper.Map<TEntity,TEntityDto>(entity),string.Format("Sorry, a problem occured when trying to delete the entity with id {0}", id)));
            }            
        }        
    }    
}
