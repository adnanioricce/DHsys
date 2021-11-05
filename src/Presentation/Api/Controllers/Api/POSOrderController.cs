using AutoMapper;
using Core.ApplicationModels.Dtos.Orders;
using Core.Entities.Catalog;
using Core.Entities.Orders;
using Core.Events.Orders;
using Core.Interfaces;
using Core.Interfaces.Financial;
using Core.Interfaces.Queues;
using Core.Models.ApplicationResources;
using Core.Validations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class POSOrderController : DefaultApiController<POSOrder,POSOrderDto>
    {
        protected readonly ITransactionService _transactionService;        
        protected readonly IRepository<Product> _productRepository;        
        protected readonly IEventBus _eventBus;
        public POSOrderController(ITransactionService transactionService,
            IRepository<POSOrder> transactionRepository,
            IRepository<Product> ProductRepository,
            IMapper mapper,
            BaseValidator<POSOrder> transactionValidator,
            IEventBus eventBus) : base(transactionRepository,mapper,transactionValidator)
        {            
            _transactionService = transactionService;
            _productRepository = ProductRepository;
            _eventBus = eventBus;
        }
        [HttpPost("create")]
        public override async Task<ActionResult<BaseResourceResponse>> CreateAsync([FromBody]POSOrderDto orderDto)
        {
            if (orderDto is null) 
                return BadRequest("invalid request, body was null");
            var order = _mapper.Map<POSOrderDto,POSOrder>(orderDto);
            var result = await _transactionService.CreateTransactionAsync(order);
            if (result.Success)
            {
                var resultDto = _mapper.Map<POSOrder, POSOrderDto>(result.Value);
                _eventBus.Publish(new OrderCreatedEvent(resultDto));
                return Ok(BaseResourceResponse.GetDefaultSuccessResponseWithObject(resultDto));
            }
            return BadRequest(BaseResourceResponse.GetDefaultFailureResponseWithObject(_mapper.Map<POSOrder,POSOrderDto>(result.Value),"Couldn't create transaction"));
        }                
    }
}
