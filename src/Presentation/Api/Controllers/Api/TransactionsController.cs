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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers.Api
{
    [Route("api/[controller]")]
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
            var result = await _transactionService.CreateTransactionAsync(_mapper.Map<TransactionDto, Transaction>(transactionDto));
            return Ok(new BaseResourceResponse<TransactionDto>{
                 Message = "entity created with success", 
                Success = true,
                ResultObject = _mapper.Map<TransactionDto>(_mapper.Map<Transaction, TransactionDto>(result.Value))
            });
        }        
        [HttpPost("legacy_create")]
        public async Task<ActionResult<BaseResourceResponse<IList<TransactionDto>>>> CreateTransactions([FromBody]IList<(string Prcodi,int qtde)> legacyTransactions)
        {
            var transactions = await _drugRepository.Query()
                                       .Where(p => legacyTransactions.Any(t => t.Prcodi == p.UniqueCode))
                                       .Select(p => new Transaction
                                       {
                                           Items = new[] {
                                               new TransactionItem
                                                   {
                                                       Drug = p,
                                                       DrugUniqueCode = p.UniqueCode,
                                                       Quantity = legacyTransactions.Where(t => t.Prcodi == p.UniqueCode)
                                                                                    .Select(p => p.qtde)
                                                                                    .Sum(),
                                                       CustomerValue =  legacyTransactions.Where(t => t.Prcodi == p.UniqueCode)
                                                                                          .Select(p => p.qtde)
                                                                                          .Sum() * p.EndCustomerPrice.Value,
                                                       CostPrice = p.CostPrice,
                                                   }
                                               }
                                       })
                                       .ToListAsync();                                       
                                       
            transactions.ForEach(transaction =>
            {
                transaction.TransactionTotal = transaction.CalculateTransactionTotal();
            });
            _transactionRepository.AddRange(transactions);
            var result = await _transactionRepository.SaveChangesAsync();
            if(result == -1)
            {
                return StatusCode(500,new BaseResourceResponse("the system can't save all the transactions"));
            }
            //? is this necessary?
            return Ok(new BaseResourceResponse<IList<TransactionDto>>("transactions save all transactions with success",null));
        }
    }
}
