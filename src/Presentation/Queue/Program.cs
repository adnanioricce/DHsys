using Core.Interfaces.Queues;
using Infrastructure.Queues;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace Queue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)                     
                .ConfigureServices((hostContext, services) =>
                {
                    
                    var configuration = hostContext.Configuration;                                        
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
                        ConfigureHandlers(eventBus);
                        return eventBus;
                    });                                        
                    services.AddHostedService<Worker>();
                });
        static void AddEventHandlers(IServiceCollection services)
        {
            //TODO:
            //services.AddTransient<OrderCreatedEventHandler>();
        }
        static void ConfigureHandlers(IEventBus eventBus)
        {
            //eventBus.Subscribe<TEvent,TEventHandler>()
        }
    }
}
