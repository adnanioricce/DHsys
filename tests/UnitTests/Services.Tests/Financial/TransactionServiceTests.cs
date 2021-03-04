using Application.Services.Financial;
using Core.Entities.Catalog;
using Core.Entities.Financial;
using Core.Interfaces;
using Core.Interfaces.Financial;
using Core.Validations;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Lib.Data;
using Tests.Lib.Seed;
using Xunit;

namespace Services.Tests.Financial
{
    public class TransactionServiceTests
    {
        public static POSOrder GetSeedTransaction()
        {
            var product = new Core.Entities.Catalog.Product{
                Id = 1,                
            };            
            var posOrder = new POSOrder();
            var quantity = 1;
            var posOrderItem = POSOrderItem.Create(product.Id,quantity,posOrder,GetMockProductRepository());            
            posOrder.AddItem(posOrderItem.Value);
            return posOrder;
        }
        public static IRepository<Product> GetMockProductRepository()
        {
            var product = new Product{
                Id = 1,                
            };
            product.UpdateStock(4, product);
            product.UpdatePrice(32.99m,29.99m,DateTimeOffset.UtcNow);
            var mock = new Mock<IRepository<Product>>();
            mock.Setup(m => m.GetBy(It.IsAny<int>()))
                .Returns(product);
            return mock.Object;
        }
        public static ITransactionService GetServiceWithSeed(IEnumerable<POSOrder> transactions)
        {
            return new POSOrderService(new FakeRepository<POSOrder>(transactions), new TransactionValidator());
        }
        public static ITransactionService GetServiceWithSeed()
        {
            return new POSOrderService(new FakeRepository<POSOrder>(new[] { GetSeedTransaction() }), new TransactionValidator());
        }
        public static ITransactionService GetService()
        {
            return new POSOrderService(new FakeRepository<POSOrder>(), new TransactionValidator());
        }        

        [Fact()]
        public void Given_CreateTransaction_When_condition_Should_expect()
        {
            //Given
            var transaction = GetSeedTransaction();
            var transactionRepository = new FakeRepository<POSOrder>();
            var service = new POSOrderService(transactionRepository, new TransactionValidator());
            //When
            var result = service.CreateTransaction(transaction);
            var createdTransaction = transactionRepository.GetBy(result.Value.Id);
            //Then
            Assert.True(result.Success);
            Assert.Equal(1, createdTransaction.Id);
        }

        [Fact()]
        public void Given_GetTodayTransactions_When_condition_Should_expect()
        {
            // Given
            var transaction = GetSeedTransaction();
            transaction.CreatedAt = DateTimeOffset.UtcNow;
            var oldTransaction = GetSeedTransaction();
            var oldDate = DateTimeOffset.UtcNow.AddDays(-2);
            oldTransaction.CreatedAt = oldDate;
            var transactionRepository = new FakeRepository<POSOrder>(new[] { transaction ,oldTransaction});
            var service = new POSOrderService(transactionRepository, new TransactionValidator());
            // When
            var result = service.GetTodayTransactions();
            // Then
            Assert.NotEmpty(result);
            Assert.Collection(result, (item) => Assert.True(item.CreatedAt.Day > oldDate.Day, "CreatedAt is a today date"));
        }

        [Fact()]
        public void Given_GetTransactions_When_condition_Should_expect()
        {
            // Given
            var transactionRepository = new FakeRepository<POSOrder>(new[] { GetSeedTransaction() });
            var service = new POSOrderService(transactionRepository, new TransactionValidator());
            // When
            var transactions = service.GetTransactions();
            // Then
            Assert.NotEmpty(transactions);
        }

        [Fact()]
        public void Given_GetTransactionsByDate_When_condition_Should_expect()
        {
            // Given            
            var todayDate = DateTimeOffset.UtcNow;
            var transactions = Enumerable.Repeat(GetSeedTransaction(), 5).Select((t,index) =>
            {
                t.CreatedAt = todayDate.AddDays(index % 2.0 == 0.0 ? -1.0 * index : 0.0);
                return t;
            });
            var transactionRepository = new FakeRepository<POSOrder>(transactions);
            var service = new POSOrderService(transactionRepository, new TransactionValidator());
            // When
            var todayTransactions = service.GetTransactionsByDate(todayDate);
            // Then
            todayTransactions.ToList().ForEach((t) => Assert.True(t.CreatedAt.Day >= todayDate.Day));
        }

        [Fact()]
        public void Given_CreateTransactionAsync_When_condition_Should_expect()
        {
            // Given
            var transaction = GetSeedTransaction();
            var service = GetService();
            // When 
            var result = service.CreateTransactionAsync(transaction).GetAwaiter().GetResult();
            // Then
            Assert.True(result.Success);
            Assert.Empty(result.Errors);
            Assert.NotNull(result.Value);
        }

        [Fact()]
        public async Task Given_GetTodayTransactionsAsync_When_condition_Should_expect()
        {
            // Given
            var todayDate = DateTimeOffset.UtcNow;
            var transactions = Enumerable.Range(0, 10).Select((i) => {
                var transaction = new POSOrder
                {
                    CreatedAt = i % 2 == 0 ? todayDate : DateTimeOffset.UtcNow.AddDays(-2)
                };                
                return transaction;
            });
            var transactionRepository = new FakeRepository<POSOrder>(transactions);
            var service = new POSOrderService(transactionRepository, new TransactionValidator());
            // When 
            //var result = Task.Run(async () => await service.GetTodayTransactionsAsync());
            //var result = ;            
            var result = await service.GetTodayTransactionsAsync().ToListAsync();            
            // Then 
            Assert.NotEmpty(result);
            result.ForEach(transaction => Assert.True(transaction.CreatedAt.Day >= todayDate.Day));
        }

        [Fact()]
        public void Given_GetTransactionsByDateAsync_When_condition_Should_expect()
        {
            // Given
            var todayDate = DateTimeOffset.UtcNow;
            var transactions = Enumerable.Repeat(GetSeedTransaction(), 5).Select((t, index) =>
            {
                t.CreatedAt = index % 2.0 == 0 ? todayDate : DateTimeOffset.UtcNow.AddDays(-1.0 * index);
                return t;
            });
            var transactionRepository = new FakeRepository<POSOrder>(transactions);
            var service = new POSOrderService(transactionRepository, new TransactionValidator());
            // When 
            var result = service.GetTransactionsByDateAsync(todayDate).GetAwaiter().GetResult();
            // Then 
            Assert.NotEmpty(result);
            result.ToList().ForEach(transaction => Assert.True(transaction.CreatedAt.Day >= todayDate.Day));
        }        
        //TODO:add remaining methods to test
    }
}