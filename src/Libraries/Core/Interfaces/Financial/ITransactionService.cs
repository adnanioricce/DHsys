using Core.ApplicationModels.Dtos.Financial;
using Core.Entities.Financial;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Financial
{
    public interface ITransactionService
    {        
        BaseResult<Transaction> CreateTransaction(Transaction transaction);
        Task<BaseResult<Transaction>> CreateTransactionAsync(Transaction transaction);
        IEnumerable<Transaction> GetTransactions();
        IEnumerable<Transaction> GetTodayTransactions();
        IAsyncEnumerable<Transaction> GetTodayTransactionsAsync();
        IEnumerable<Transaction> GetTransactionsByDate(DateTimeOffset dateTime);
        Task<IEnumerable<Transaction>> GetTransactionsByDateAsync(DateTimeOffset dateTime);                

    }
}
