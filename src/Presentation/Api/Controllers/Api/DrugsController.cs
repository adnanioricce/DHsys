﻿using System;
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
                return StatusCode(404,new BaseResourceResponse<IList<DrugDto>>
                {
                    Message = $"there is no drug with the pattern {query.Name} on it's name"                    
                });
            }
            var drugDtos = _mapper.Map<List<Drug>, IList<DrugDto>>(drugs);
            var resultValue = new BaseResourceResponse<IList<DrugDto>>("drugs created with success", drugDtos);
            return Ok(resultValue);
        }
        // GET: api/Drugs/search/{barcode}
        [HttpGet("search/{barcode}")]
        public ActionResult<BaseResourceResponse<DrugDto>> GetDrugByBarCode([FromRoute]string barcode)
        {
            var drug = _drugService.SearchDrugByBarCode(barcode);
            if (drug is null)
            {
                return StatusCode(404, new BaseResourceResponse<DrugDto>
                {
                    Message = $"There is no drug with barcode {barcode}",
                    ResultObject = null
                });
            }
            return Ok(new BaseResourceResponse<DrugDto>("",_mapper.Map<Drug,DrugDto>(drug)));            
        }
        // POST: api/Drugs/create
        [HttpPost("create")]
        public ActionResult<BaseResourceResponse> CreateDrug(DrugDto drugDto)
        {
            var drug = _mapper.Map<DrugDto, Drug>(drugDto);
            _drugService.CreateDrug(drug);
            return Ok(new BaseResourceResponse<object>
            {
                Message = "entity created with success",
                ResultObject = new
                {
                    CreatedIds = drug.Id,
                },
                Success = true
            });
        }        
    }
}
