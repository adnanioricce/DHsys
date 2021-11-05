using Core.Events;

namespace Core.Interfaces.Queues
{
    public interface IEventBus
    {
        void Publish(Event @event);
        void Subscribe<TEvent,TEventHandler>() 
            where TEvent : Event
            where TEventHandler : IEventHandler<TEvent>;
        void Subscribe<TEventHandler>(string eventName)
            where TEventHandler : IDynamicEventHandler;

        void Unsubscribe<TEvent,TEventHandler>()
            where TEvent : Event
            where TEventHandler : IEventHandler<TEvent>;
        void Unsubscribe<TEventHandler>(string eventName)
            where TEventHandler : IDynamicEventHandler;
    }
}
