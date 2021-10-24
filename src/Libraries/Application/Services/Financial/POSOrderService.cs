﻿using AutoMapper;
using Core.ApplicationModels.Dtos.Financial;
using Core.Entities.Financial;
using Core.Entities.Orders;
using Core.Interfaces;
using Core.Interfaces.Financial;
using Core.Models;
using Core.Results;
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
        public Result<POSOrder> CreateTransaction(POSOrder transaction)
        {            
            _transactionRepository.Add(transaction);
            _transactionRepository.SaveChanges();
            return Result<POSOrder>.Ok(transaction);
        }

        public IEnumerable<POSOrder> GetTodayTransactions()
        {
            foreach(var transaction in _transactionRepository.Query())
            {
                if(transaction.CreatedAt.Day == DateTimeOffset.UtcNow.Day)
                {
                    yield return transaction;
                }
            }            
        }

        public IEnumerable<POSOrder> GetTransactions()
        {            
            return _transactionRepository.GetAll();
        }

        public IEnumerable<POSOrder> GetTransactionsByDate(DateTimeOffset dateTime)
        {
            return _transactionRepository.Query().Where(d => d.CreatedAt >= dateTime);                
        }        

        public async Task<Result<POSOrder>> CreateTransactionAsync(POSOrder transaction)
        {
            var validationResult = _validator.Validate(transaction);
            if (!validationResult.IsValid) {
                AppLogger.Log.Information("Failed to validate transaction at {className}. Validation Result:{@validationResult}", this.GetType().Name, validationResult);
                return Result<POSOrder>.Fail(transaction,
                    validationResult.Errors.Select(e => new Error(e.ErrorCode,$"validation {e.Severity} failed for property {e.PropertyName} with code {e.ErrorCode}. Reason:{e.ErrorMessage}")).ToArray());
            }
            _transactionRepository.Add(transaction);
            await _transactionRepository.SaveChangesAsync();
            return Result<POSOrder>.Ok(transaction);
        }

        public IAsyncEnumerable<POSOrder> GetTodayTransactionsAsync()
        {
            return _transactionRepository.GetAsyncEnumerable()
                                         .Where(t => t.CreatedAt.Day == DateTimeOffset.UtcNow.Day);
        }

        public async Task<IEnumerable<POSOrder>> GetTransactionsByDateAsync(DateTimeOffset dateTime)
        {
            return await GetTransactionsByDate(dateTime).AsQueryable()
                                                        .ToListAsync();
        }        
    }
}
