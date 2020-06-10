using AutoMapper;
using Core.ApplicationModels.Dtos.Financial;
using Core.Entities.Financial;
using Core.Interfaces;
using Core.Interfaces.Financial;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Financial
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<Transaction> _transactionRepository;
        private readonly IMapper _mapper;
        public TransactionService(IRepository<Transaction> transactionRepository)
        {
            _transactionRepository = transactionRepository;            
        }
        public BaseResult<Transaction> CreateTransaction(Transaction transaction)
        {            
            _transactionRepository.Add(transaction);
            _transactionRepository.SaveChanges();
            return new BaseResult<Transaction>
            {
                Success = true,
                Value = transaction            
            };
        }

        public IEnumerable<Transaction> GetTodayTransactions()
        {
            return _transactionRepository.Query()
                .Where(t => t.CreatedAt.Day == DateTimeOffset.UtcNow.Day);
        }

        public IEnumerable<Transaction> GetTransactions()
        {            
            return _transactionRepository.GetAll();
        }

        public IEnumerable<Transaction> GetTransactionsByDate(DateTimeOffset dateTime)
        {
            return _transactionRepository.Query()
                .Where(d => d.CreatedAt >= dateTime);                
        }

        public IEnumerable<Transaction> GetTransactionsByRange(int biggerThan = 0, int lessThan = 50)
        {
            return _transactionRepository.Query()
                .Where(d => d.TransactionTotal > biggerThan && d.TransactionTotal < lessThan);
        }

        public async Task<BaseResult<Transaction>> CreateTransactionAsync(Transaction transaction)
        {            
            _transactionRepository.Add(transaction);
            await _transactionRepository.SaveChangesAsync();
            return new BaseResult<Transaction>
            {
                Success = true,
                Value = transaction
            };
        }

        public async Task<IEnumerable<Transaction>> GetTodayTransactionsAsync()
        {
            return await GetTodayTransactions()
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByDateAsync(DateTimeOffset dateTime)
        {
            return await GetTransactionsByDate(dateTime).AsQueryable().ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByRangeAsync(int biggerThan = 0, int lessThan = 50)
        {
            return await GetTransactionsByRange(biggerThan, lessThan).AsQueryable().ToListAsync();
        }
    }
}
