using AutoMapper;
using Core.ApplicationModels.Dtos.Financial;
using Core.Entities.Financial;
using Core.Entities.Orders;
using Core.Interfaces;
using Core.Interfaces.Financial;
using Core.Models;
using Core.Validations;
using Infrastructure.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Financial
{
    public class POSOrderService : ITransactionService
    {
        protected readonly IRepository<POSOrder> _transactionRepository;        
        protected readonly BaseValidator<POSOrder> _validator;
        public POSOrderService(IRepository<POSOrder> transactionRepository,BaseValidator<POSOrder> transactionValidator)
        {
            _transactionRepository = transactionRepository;
            _validator = transactionValidator;
        }
        public BaseResult<POSOrder> CreateTransaction(POSOrder transaction)
        {            
            _transactionRepository.Add(transaction);
            _transactionRepository.SaveChanges();
            return new BaseResult<POSOrder>
            {
                Success = true,
                Value = transaction            
            };
        }
        
        public IEnumerable<POSOrder> GetTodayTransactions()
        {
            var dataAtual = DateTimeOffset.UtcNow;
            var dataInicio = new DateTimeOffset(dataAtual.Year,dataAtual.Month,dataAtual.Day,0,0,0,0,dataAtual.Offset);
            return GetTransactionsByDate(dataInicio,dataInicio.AddHours(23.99));
        }
        public IEnumerable<POSOrder> GetTransactions()
        {            
            return _transactionRepository.GetAll();
        }

        
        public async Task<BaseResult<POSOrder>> CreateTransactionAsync(POSOrder transaction)
        {
            var validationResult = _validator.Validate(transaction);
            if (!validationResult.IsValid) {
                AppLogger.Log.Information("Failed to validate transaction at {className}. Validation Result:{@validationResult}", this.GetType().Name, validationResult);
                return BaseResult<POSOrder>.Failed(validationResult.Errors.Select(e => $"validation {e.Severity} failed for property {e.PropertyName} with code {e.ErrorCode}. Reason:{e.ErrorMessage}"),transaction);
            }
            _transactionRepository.Add(transaction);
            await _transactionRepository.SaveChangesAsync();
            return new BaseResult<POSOrder>
            {
                Success = true,
                Value = transaction
            };
        }
        //TODO: Edit limit instead till date, instead of give a offset as parameter
        public IEnumerable<POSOrder> GetTransactionsByDate(DateTimeOffset startDate)
        {
            return _transactionRepository.Query().Where(d => d.CreatedAt >= startDate);                
        }        
        public IEnumerable<POSOrder> GetTransactionsByDate(DateTimeOffset startDate,DateTimeOffset limit)
        {            
            return _transactionRepository.Query()
                .Where(t => t.CreatedAt >= startDate && t.CreatedAt <= limit);
        }
        public IAsyncEnumerable<POSOrder> GetTodayTransactionsAsync()
        {            
            return GetTodayTransactions().ToAsyncEnumerable();
        }

        public async Task<IEnumerable<POSOrder>> GetTransactionsByDateAsync(DateTimeOffset startDate)
        {
            return await GetTransactionsByDate(startDate).AsQueryable()
                                                        .ToListAsync();
        }        
    }
}
