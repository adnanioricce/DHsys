using Core.Entities.Financial;
using System;

namespace DAL.Seed
{
    public class TransactionSeed : IDataObjectSeed<Transaction>
    {
        public Transaction GetSeedObject()
        {
            var transaction = new Transaction {
                CreatedAt = DateTimeOffset.UtcNow,
                UniqueCode = Guid.NewGuid().ToString(),
                HasDealWithStore = false,
                PaymentMethod = PaymentMethods.InHands
            };
            var item = new TransactionItem {
                CostPrice = 23.99m,
                CreatedAt = DateTimeOffset.UtcNow,
                CustomerValue = 39.99m,
                Drug = new DrugSeed().GetSeedObject(),
                Quantity = 4,
                UniqueCode = Guid.NewGuid().ToString(),
                Transaction = transaction
            };
            transaction.AddItems(item);            
            return transaction;
        }
    }
}
