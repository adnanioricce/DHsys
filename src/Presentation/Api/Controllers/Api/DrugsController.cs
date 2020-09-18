using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using AutoMapper;
using Core.ApplicationModels.Dtos.Catalog;
using Core.Entities.Catalog;
using Core.Entities.Legacy;
using Core.Interfaces;
using Core.Models.ApplicationResources;
using Core.Models.ApplicationResources.Requests;
using Core.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Api.Controllers.Api
{    
    public class DrugsController : DefaultApiController<Drug,DrugDto>
    {
        private readonly IDrugService _drugService;        
        public DrugsController(IRepository<Drug> drugRepository,IMapper mapper,BaseValidator<Drug> drugValidator, IDrugService drugService) : base(drugRepository,mapper,drugValidator)
        {
            _drugService = drugService;
        }
        // GET: api/Drugs/search/{name}
        [HttpGet("search/list")]
        public async Task<ActionResult<BaseResourceResponse<IList<DrugDto>>>> GetDrugsByName([FromQuery]string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Log.Information("Error 404 when trying to search for drugs with given name, name parameter was null.");
                return StatusCode(404, BaseResourceResponse.GetFailureResponseWithMessage("name parameter is null"));
            }
            var drugs = await _drugService.SearchDrugsByNameAsync(name);
            if(drugs.Count() == 0)
            {                
                Log.Information("404 error returned on DrugsController for name {name}",name);
                return StatusCode(404, new BaseResourceResponse<IList<DrugDto>>
                {
                    Message = $"there is no drug with the pattern {name} on it's name",
                    Success = false,
                });
            }
            var drugDtos = _mapper.Map<List<Drug>, IList<DrugDto>>(drugs.ToList());
            var resultValue = new BaseResourceResponse<IList<DrugDto>>("drugs created with success", drugDtos);
            return Ok(resultValue);
        }
        // GET: api/Drugs/search/{barcode}
        [HttpGet("search/{barcode}")]
        public async Task<ActionResult<BaseResourceResponse<DrugDto>>> GetDrugByBarCode([FromRoute]string barcode)
        {
            var drug = await _drugService.SearchDrugByBarCodeAsync(barcode);
            if (drug is null)
            {
                Log.Information("404 error returned on DrugsController for barcode {barcode}", barcode);
                return StatusCode(404, new BaseResourceResponse<DrugDto>
                {
                    Message = $"There is no drug with barcode {barcode}",
                    ResultObject = null
                });
            }
            return Ok(new BaseResourceResponse<DrugDto>("drug entry created successfully", _mapper.Map<Drug,DrugDto>(drug)));            
        }
        //[HttpGet("search/{id}")]
        //public async Task<ActionResult<BaseResourceResponse<DrugDto>>> GetDrugByBarCode([FromRoute] int id)
        //{
        //    var drug = await _drugService.SearchDrugByBarCodeAsync(barcode);
        //    if (drug is null)
        //    {
        //        Log.Information("404 error returned on DrugsController for barcode {barcode}", barcode);
        //        return StatusCode(404, new BaseResourceResponse<DrugDto>
        //        {
        //            Message = $"There is no drug with barcode {barcode}",
        //            ResultObject = null
        //        });
        //    }
        //    return Ok(new BaseResourceResponse<DrugDto>("drug entry created successfully", _mapper.Map<Drug, DrugDto>(drug)));
        //}
        // POST: api/Drugs/create
        [HttpPost("create")]
        [ProducesResponseType(typeof(BaseResourceResponse<object>), 200)]
        [ProducesResponseType(typeof(BaseResourceResponse<object>), 500)]
        public ActionResult<BaseResourceResponse> CreateDrug(DrugDto drugDto)
        {
            var drug = _mapper.Map<DrugDto, Drug>(drugDto);
            try
            {
                _drugService.CreateDrug(drug);
            }
            catch (Exception ex)
            {
                Log.Error("Exception throwed whem trying to create new drug entry. Exception: {@ex} \n Object Dto: {@drugDto} \n Entity Object(mapped): {@drug}",ex, drugDto, drug);
                return StatusCode(500, BaseResourceResponse<DrugDto>.GetDefaultFailureResponseWithObject(drugDto, "couldn't create drug entry for given object"));
            }
            return Ok(new BaseResourceResponse<DrugDto>
            {
                Message = "entity created with success",
                ResultObject = _mapper.Map<Drug,DrugDto>(drug),
                Success = true
            });
        }        
    }
}
