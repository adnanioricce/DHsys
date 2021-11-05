using Core.Interfaces.Queues;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Queue
{
    public class TransactionEventHandler : IEventHandler<TransactionEvent>
    {
        private readonly ILogger<TransactionEventHandler> _logger;
        public TransactionEventHandler(ILogger<TransactionEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(TransactionEvent @event)
        {
            _logger.LogInformation("Transaction {@id} received,{@value} From {@from} To {@to}",@event.Id,@event.Value,@event.From,@event.To);
            return Task.CompletedTask;
        }
    }
}
