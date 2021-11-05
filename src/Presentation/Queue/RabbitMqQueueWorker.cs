using Core.Interfaces.Queues;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queue
{    
    public class RabbitMqQueueWorker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;        
        private readonly IEventBus _eventBus;
        public RabbitMqQueueWorker(ILogger<Worker> logger,IEventBus eventBus)
        {
            _logger = logger;
            _eventBus = eventBus;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("RabbitMQ worker is starting.");

            stoppingToken.Register(() => _logger.LogInformation("#1 RabbitMQ worker is stopping."));

            //while (!stoppingToken.IsCancellationRequested)
            //{
                
            //}
        }        
    }
}
