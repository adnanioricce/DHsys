using Core.Entities.Financial;
using Core.Entities.Orders;
using System;

namespace DAL.Seed
{
    public class POSOrderSeed : IDataObjectSeed<POSOrder>
    {
        public POSOrder GetSeedObject()
        {
            var POSOrder = new POSOrder {
                CreatedAt = DateTimeOffset.UtcNow,
                UniqueCode = Guid.NewGuid().ToString()
            };            
            // var product = new ProductSeed().GetSeedObject();
            return POSOrder;
        }
    }
}
