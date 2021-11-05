using RabbitMQ.Client;

namespace Infrastructure.Queues
{
    public interface IRabbitMQPersistentConnection
    {
        bool IsConnected { get; }

        IModel CreateModel();
        void Dispose();
        bool TryConnect();
    }
}