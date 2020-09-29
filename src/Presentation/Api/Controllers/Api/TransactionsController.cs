using AutoMapper;
using Core.ApplicationModels.Dtos.Financial;
using Core.Entities.Catalog;
using Core.Entities.Financial;
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
    public class TransactionsController : DefaultApiController<Transaction,TransactionDto>
    {
        protected readonly ITransactionService _transactionService;
        protected readonly IRepository<Transaction> _transactionRepository;
        protected readonly IRepository<Drug> _drugRepository;        
        public TransactionsController(ITransactionService transactionService,
            IRepository<Transaction> transactionRepository,
            IRepository<Drug> drugRepository,
            IMapper mapper,
            BaseValidator<Transaction> drugValidator) : base(transactionRepository,mapper,drugValidator)
        {
            _transactionRepository = transactionRepository;
            _transactionService = transactionService;
            _drugRepository = drugRepository;            
        }
        [HttpPost("create")]
        public override async Task<ActionResult<BaseResourceResponse>> CreateAsync([FromBody]TransactionDto transactionDto)
        {
            if (transactionDto is null) return BadRequest("invalid request, body was null");
            var transaction = _mapper.Map<TransactionDto,Transaction>(transactionDto);
            try
            {
                var result = await _transactionService.CreateTransactionAsync(transaction);
                return Ok(new BaseResourceResponse<TransactionDto>
                {
                    Message = "entity created with success",
                    Success = true,
                    //TODO: Return dto of the created transaction
                    ResultObject = null
                });
            }
            catch(Exception ex)
            {
                Log.Error("Exception throwed when trying to create transaction. Exception:{@ex} \n Transaction Dto:{@transactionDto}", ex, transactionDto);
                return StatusCode(500, BaseResourceResponse<TransactionDto>.GetDefaultFailureResponseWithObject(transactionDto,"couldn't create transaction entity for given object"));
            }
            
        }                
    }
}
