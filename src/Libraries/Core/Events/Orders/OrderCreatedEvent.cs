using Core.ApplicationModels.Dtos.Orders;
using Core.Entities.Orders;

namespace Core.Events.Orders
{
    public class OrderCreatedEvent : Event
    {
        public OrderCreatedEvent(POSOrderDto orderDto)
        {
            Order = orderDto;
        }        
        public POSOrderDto Order { get; }
    }
}
