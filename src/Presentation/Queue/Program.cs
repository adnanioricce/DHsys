using Core.Interfaces.Queues;
using Infrastructure.Queues;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Queue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        static void LogQueue(IModel channel,string[] args)
        {
            channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName,
                              exchange: "logs",
                              routingKey: "");

            Console.WriteLine(" [*] Waiting for logs.");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] {0}", message);
            };
            channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }        
        static void TaskHelloQueue(IModel channel,string[] args)
        {
            channel.QueueDeclare(queue: "hello",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
            channel.QueueDeclare(
                queue: "task_hello",
                durable: true,
                exclusive:false,
                autoDelete:false,
                arguments:null);

            channel.BasicQos(prefetchSize:0,prefetchCount:1,global:false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
            };

            channel.BasicConsume(queue: "hello",
                                 autoAck: true,
                                 consumer: consumer);
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)                
                .ConfigureServices((hostContext, services) =>
                {
                    
                    var configuration = hostContext.Configuration;                    
                    services.AddTransient<TransactionEventHandler>();
                    services.Configure<BusesSettings>(configuration.GetSection("EventBuses"));
                    services.AddSingleton<IRabbitMQPersistentConnection>(sp => { 
                        var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();
                        var config = configuration.Get<BusesSettings>();
                        var engine = configuration["EventBuses:Default:Engine"];
                        var connection = configuration["EventBuses:Default:Connection"];                        
                        var username = configuration["EventBuses:Default:UserName"];
                        var password = configuration["EventBuses:Default:Password"];
                        var retryCount = string.IsNullOrEmpty(configuration["EventBuses:Default:RetryCount"]) ? 5 : int.Parse(configuration["EventBuses:Default:RetryCount"]);

                        var factory = new ConnectionFactory()
                        {
                            HostName = connection,
                            DispatchConsumersAsync = true
                        };

                        if (!string.IsNullOrEmpty(username))
                        {
                            factory.UserName = username;
                        }

                        if (!string.IsNullOrEmpty(password))
                        {
                            factory.Password = password;
                        }
                        return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
                    });
                    services.AddSingleton<IEventBusSubscriptionsManager,SubscriptionsManager>();
                    services.AddSingleton<IEventBus,RabbitMQEventBus>(sp => {
                        var persistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                        var eventSubscriptionManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();
                        var logger = sp.GetRequiredService<ILogger<RabbitMQEventBus>>();
                        var eventBus = new RabbitMQEventBus(persistentConnection,eventSubscriptionManager,logger,sp,configuration["SubscriptionClientName"],5);
                        eventBus.Subscribe<TransactionEvent,TransactionEventHandler>();
                        return eventBus;
                    });
                    
                    services.AddHostedService<RabbitMqQueueWorker>();
                    services.AddHostedService<Worker>();
                });
            
    }
}
