using Core.Entities.Financial;
using System;

namespace DAL.Seed
{
    public class POSOrderSeed : IDataObjectSeed<POSOrder>
    {
        public POSOrder GetSeedObject()
        {
            var POSOrder = new POSOrder {
                CreatedAt = DateTimeOffset.UtcNow,
                UniqueCode = Guid.NewGuid().ToString(),
                HasDealWithStore = false,
                PaymentMethod = PaymentMethods.InHands,
                ConsumerCode = Guid.NewGuid().ToString()
            };
            var item = new POSOrderItem {
                CostPrice = 23.99m,
                CreatedAt = DateTimeOffset.UtcNow,
                CustomerValue = 39.99m,
                Product = new ProductSeed().GetSeedObject(),
                Quantity = 4,
                UniqueCode = Guid.NewGuid().ToString(),
                POSOrder = POSOrder
            };
            POSOrder.AddItems(item);            
            return POSOrder;
        }
    }
}
