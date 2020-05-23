using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Core.Entities.Catalog;
using Core.Entities.LegacyScaffold;
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
        public DrugsController(IDrugService drugService)
        {
            _drugService = drugService;
        }
        // GET: api/Drugs/search/{name}
        [HttpGet("search/list")]
        public ActionResult<BaseResourceResponse<IEnumerable<Drug>>> GetDrugsByName([FromQuery]CatalogQuery query)
        {
            return Ok(new BaseResourceResponse<IEnumerable<Drug>>
            {
                ResultObject = _drugService.SearchDrugsByName(query.Name),
                Success = true
            });
        }
        // GET: api/Drugs/search/{barcode}
        [HttpGet("search")]
        public ActionResult<BaseResourceResponse<Drug>> GetDrugByBarCode(string barcode)
        {
            return Ok(new BaseResourceResponse<Drug>
            {
                ResultObject = _drugService.SearchDrugByBarCode(barcode),
                Success = true
            });
        }
        [HttpPost("create_from_produtos")]
        public ActionResult<BaseResourceResponse<IEnumerable<Drug>>> CreateDrugsFromCollectionOfProduto([FromBody]CreateDrugFromProdutoRequest request)
        {            
            if (!request.CreatedProdutos.Any()) return new BadRequestObjectResult("there is no data to save"); 
            //What I should do here?
            _drugService.CreateDrugs(request.CreatedProdutos);
            
            return Ok(new BaseResourceResponse<IEnumerable<Drug>>
            {                
                Success = true
            });
        }        
        [HttpPost("create_from_produto")]
        public ActionResult<BaseResourceResponse> CreateDrugFromProduto([FromBody]Produto produto)
        {
            _drugService.CreateDrug(produto);
            return Ok(new BaseResourceResponse
            {
                ErrorMessage = "",
                Success = true
            });
        }
        [HttpPost("create")]
        public ActionResult<BaseResourceResponse> CreateDrug(Drug drug)
        {
            _drugService.CreateDrug(drug);
            return Ok(new BaseResourceResponse
            {
                ErrorMessage = "",
                Success = true
            });
        }
    }
}
