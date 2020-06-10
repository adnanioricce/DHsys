using AutoMapper;
using Core.ApplicationModels.Dtos.Financial;
using Core.Entities.Financial;
using Core.Interfaces.Financial;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;
        public TransactionsController(ITransactionService transactionService,
            IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }
        [HttpPost("create")]
        public async Task<ActionResult<BaseResult<TransactionDto>>> CreateTransaction([FromBody]TransactionDto transactionDto)
        {
            if (transactionDto is null) return BadRequest("invalid request, body was null");
            var result = await _transactionService.CreateTransactionAsync(_mapper.Map<TransactionDto, Transaction>(transactionDto));
            return Ok(BaseResult<TransactionDto>.CreateSuccessResult("entity created with success",_mapper.Map<TransactionDto>(_mapper.Map<Transaction,TransactionDto>(result.Value))));
        }        
    }
}
