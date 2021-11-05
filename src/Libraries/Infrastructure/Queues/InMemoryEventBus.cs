using Core.Events;
using Core.Interfaces.Queues;
using System;
using System.Collections.Concurrent;

namespace Infrastructure.Queues
{
    public class InMemoryEventBus : IEventBus
    {        
        public void Publish(Event @event)
        {
            throw new System.NotImplementedException();
        }

        public void Subscribe<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : IEventHandler<TEvent>
        {
            throw new System.NotImplementedException();
        }

        public void Subscribe<TEventHandler>(string eventName) where TEventHandler : IDynamicEventHandler
        {
            throw new System.NotImplementedException();
        }

        public void Unsubscribe<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : IEventHandler<TEvent>
        {
            throw new System.NotImplementedException();
        }

        public void Unsubscribe<TEventHandler>(string eventName) where TEventHandler : IDynamicEventHandler
        {
            throw new System.NotImplementedException();
        }
    }
}
