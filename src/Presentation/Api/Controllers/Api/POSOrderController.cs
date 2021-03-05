using AutoMapper;
using Core.ApplicationModels.Dtos.Financial;
using Core.ApplicationModels.Dtos.Orders;
using Core.Entities.Catalog;
using Core.Entities.Financial;
using Core.Entities.Orders;
using Core.Interfaces;
using Core.Interfaces.Financial;
using Core.Models.ApplicationResources;
using Core.Validations;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Api.Controllers.Api
{
    [Route("api/[Controller]")]
    [ApiController]
    public class POSOrderController : DefaultApiController<POSOrder,POSOrderDto>
    {
        protected readonly ITransactionService _transactionService;        
        protected readonly IRepository<Product> _productRepository;        
        public POSOrderController(ITransactionService transactionService,
            IRepository<POSOrder> transactionRepository,
            IRepository<Product> ProductRepository,
            IMapper mapper,
            BaseValidator<POSOrder> transactionValidator) : base(transactionRepository,mapper,transactionValidator)
        {            
            _transactionService = transactionService;
            _productRepository = ProductRepository;            
        }
        [HttpPost("create")]
        public override async Task<ActionResult<BaseResourceResponse>> CreateAsync([FromBody]POSOrderDto transactionDto)
        {
            if (transactionDto is null) return BadRequest("invalid request, body was null");
            var transaction = _mapper.Map<POSOrderDto,POSOrder>(transactionDto);            
            var result = await _transactionService.CreateTransactionAsync(transaction);
            if (result.Success)
            {
                return Ok(BaseResourceResponse.GetDefaultSuccessResponseWithObject(_mapper.Map<POSOrder, POSOrderDto>(result.Value)));                
            }
            return BadRequest(BaseResourceResponse.GetDefaultFailureResponseWithObject(_mapper.Map<POSOrder,POSOrderDto>(result.Value),"Couldn't create transaction"));
        }                
    }
}
