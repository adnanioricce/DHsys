using Core.ApplicationModels.Dtos.Financial;
using Core.Entities.Financial;
using Core.Entities.Orders;
using Core.Models;
using Core.Models.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Financial
{
    public interface ITransactionService
    {        
        Result<POSOrder> CreateTransaction(POSOrder transaction);
        Task<Result<POSOrder>> CreateTransactionAsync(POSOrder transaction);
        IEnumerable<POSOrder> GetTransactions();
        IEnumerable<POSOrder> GetTodayTransactions();
        IAsyncEnumerable<POSOrder> GetTodayTransactionsAsync();
        IEnumerable<POSOrder> GetTransactionsByDate(DateTimeOffset dateTime);
        Task<IEnumerable<POSOrder>> GetTransactionsByDateAsync(DateTimeOffset dateTime);                

    }
}
