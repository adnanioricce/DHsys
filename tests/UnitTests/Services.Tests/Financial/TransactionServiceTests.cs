using Application.Services.Financial;
using Core.Entities.Financial;
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
            var transaction = new Transaction{
                TransactionTotal = 32.99m,
                Items = new [] {
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
            var service = new TransactionService(transactionRepository);
            //When
            var result = service.CreateTransaction(transaction);
            var createdTransaction = transactionRepository.GetBy(result.Value.Id);
            //Then
            Assert.True(result.Success);
            Assert.Equal(1, createdTransaction.Id);
        }        
        //TODO:add remaining methods to test
    }
}