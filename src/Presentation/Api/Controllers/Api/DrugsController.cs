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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugsController : ControllerBase
    {
        private readonly IDrugService _drugService;
        private readonly IMapper _mapper;        
        public DrugsController(IDrugService drugService,IMapper mapper)
        {
            _drugService = drugService;
            _mapper = mapper;
        }
        // GET: api/Drugs/search/{name}
        [HttpGet("search/list")]
        public ActionResult<BaseResourceResponse<IList<DrugDto>>> GetDrugsByName([FromQuery]CatalogQuery query)
        {
            var drugs = _drugService.SearchDrugsByName(query.Name).ToList();
            if(drugs.Count == 0)
            {                
                return BadRequest($"there is no drug with the pattern {query.Name} on it's name");                
            }
            return Ok(new BaseResourceResponse<IList<DrugDto>>("drugs created with success",drugs.Select(d => _mapper.Map<Drug, DrugDto>(d)).ToList()));            
        }
        // GET: api/Drugs/search/{barcode}
        [HttpGet("search")]
        public ActionResult<BaseResourceResponse<Drug>> GetDrugByBarCode([FromRoute]string barcode)
        {
            var drug = _drugService.SearchDrugByBarCode(barcode);
            if(drug is null)
            {
                return BadRequest($"There is no drug with name {barcode}");
            }
            return Ok(new BaseResourceResponse<Drug>("", drug));            
        }
        // POST: api/Drugs/create
        [HttpPost("create")]
        public ActionResult<BaseResourceResponse> CreateDrug(Drug drug)
        {
            _drugService.CreateDrug(drug);
            return Ok(new BaseResourceResponse
            {
                Message = "",
                Success = true
            });
        }        
    }
}
