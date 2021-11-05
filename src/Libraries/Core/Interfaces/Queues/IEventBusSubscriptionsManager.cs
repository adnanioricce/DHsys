using Core.Events;
using System;
using System.Collections.Generic;

namespace Core.Interfaces.Queues
{
    public interface IEventBusSubscriptionsManager
    {
        bool IsEmpty { get; }
        event EventHandler<string> OnEventRemoved;
        void AddDynamicSubscription<TH>(string eventName)
           where TH : IDynamicEventHandler;

        void AddSubscription<TEvent, TEventHandler>()
           where TEvent : Event
           where TEventHandler : IEventHandler<TEvent>;

        void RemoveSubscription<TEvent, TEventHandler>()
             where TEventHandler : IEventHandler<TEvent>
             where TEvent : Event;
        void RemoveDynamicSubscription<TEventHandler>(string eventName)
            where TEventHandler : IDynamicEventHandler;

        bool HasSubscriptionsForEvent<T>() where T : Event;
        bool HasSubscriptionsForEvent(string eventName);
        Type GetEventTypeByName(string eventName);
        void Clear();
        IEnumerable<Subscription> GetHandlersForEvent<T>() where T : Event;
        IEnumerable<Subscription> GetHandlersForEvent(string eventName);
        string GetEventKey<T>();
    }
}
