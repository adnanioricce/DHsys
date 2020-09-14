using AutoMapper;
using Core.ApplicationModels.Dtos.Financial;
using Core.Entities.Catalog;
using Core.Entities.Financial;
using Core.Interfaces;
using Core.Interfaces.Catalog;
using Core.Interfaces.Financial;
using Core.Models;
using Core.Models.ApplicationResources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.Api
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IRepository<Transaction> _transactionRepository;
        private readonly IRepository<Drug> _drugRepository;
        private readonly IMapper _mapper;
        public TransactionsController(ITransactionService transactionService,
            IRepository<Transaction> transactionRepository,
            IRepository<Drug> drugRepository,
            IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _transactionService = transactionService;
            _drugRepository = drugRepository;
            _mapper = mapper;
        }
        [HttpPost("create")]
        public async Task<ActionResult<BaseResourceResponse<TransactionDto>>> CreateTransaction([FromBody]TransactionDto transactionDto)
        {
            if (transactionDto is null) return BadRequest("invalid request, body was null");
            var transaction = transactionDto.ToModel();
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
                throw;
            }
            
        }                
    }
}
