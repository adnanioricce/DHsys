using Application.Services.Financial;
using Core.Entities.Financial;
using Core.Validations;
using Tests.Lib.Data;
using Tests.Lib.Seed;
using Xunit;

namespace Services.Tests.Financial
{
    public class TransactionServiceTests
    {
        [Fact]
        public void Given_transaction_to_be_created_when_passes_transaction_object_Then_save_it_and_return_status()
        {
            //Given
            var transaction = new Transaction
            {
                Items = new[] {
                    new TransactionItem
                    {
                        Drug = DrugSeed.BaseCreateDrugEntity(),
                        DrugUniqueCode = "123456",
                        CustomerValue = 32.99m,
                        CostPrice = 29.99m,
                        Quantity = 1,

                    }
                }
            };
            var transactionRepository = new FakeRepository<Transaction>();
            var service = new TransactionService(transactionRepository, new TransactionValidator());
            //When
            var result = service.CreateTransaction(transaction);
            var createdTransaction = transactionRepository.GetBy(result.Value.Id);
            //Then
            Assert.True(result.Success);
            Assert.Equal(1, createdTransaction.Id);
        }        

        [Fact()]
        public void Given_CreateTransaction_When_condition_Should_expect()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void Given_GetTodayTransactions_When_condition_Should_expect()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void Given_GetTransactions_When_condition_Should_expect()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void Given_GetTransactionsByDate_When_condition_Should_expect()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void Given_GetTransactionsByRange_When_condition_Should_expect()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void Given_CreateTransactionAsync_When_condition_Should_expect()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void Given_GetTodayTransactionsAsync_When_condition_Should_expect()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void Given_GetTransactionsByDateAsync_When_condition_Should_expect()
        {
            Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void Given_GetTransactionsByRangeAsync_When_condition_Should_expect()
        {
            Assert.True(false, "This test needs an implementation");
        }
        //TODO:add remaining methods to test
    }
}