using Core.Events;
using Core.Interfaces.Queues;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Queues
{
    public class SubscriptionsManager : IEventBusSubscriptionsManager
    {
        private readonly Dictionary<string, List<Subscription>> _handlers = new Dictionary<string, List<Subscription>>();
        private readonly List<Type> _eventTypes = new List<Type>();
        public bool IsEmpty => _handlers.Keys.Any();

        public event EventHandler<string> OnEventRemoved;

        public void AddDynamicSubscription<TEventHandler>(string eventName) where TEventHandler : IDynamicEventHandler
        {
            AddSubscription<TEventHandler>(eventName, isDynamic: true);
        }

        public void AddSubscription<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : IEventHandler<TEvent>
        {
            AddSubscription<TEventHandler>(GetEventKey<TEvent>(),false);
            if (!_eventTypes.Contains(typeof(TEvent)))
            {
                _eventTypes.Add(typeof(TEvent));
            }
        }

        public void Clear() => _handlers.Clear();        

        public string GetEventKey<T>() => typeof(T).Name;

        public Type GetEventTypeByName(string eventName) => _eventTypes.SingleOrDefault(t => t.Name == eventName);

        public IEnumerable<Subscription> GetHandlersForEvent<TEvent>() where TEvent : Event
        {
            var key = GetEventKey<TEvent>();
            return _handlers[key];
        }

        public IEnumerable<Subscription> GetHandlersForEvent(string eventName)
            => _handlers[eventName];

        public bool HasSubscriptionsForEvent<T>() where T : Event
            => _handlers.ContainsKey(GetEventKey<T>());

        public bool HasSubscriptionsForEvent(string eventName)
            => _handlers.ContainsKey(eventName);

        public void RemoveDynamicSubscription<TEventHandler>(string eventName) where TEventHandler : IDynamicEventHandler
        {
            if(!HasSubscriptionsForEvent(eventName))
                return;

            RemoveEvent(eventName,typeof(TEventHandler));
        }

        public void RemoveSubscription<TEvent, TEventHandler>()
            where TEvent : Event
            where TEventHandler : IEventHandler<TEvent>
        {
            if (!HasSubscriptionsForEvent<TEvent>())
                return;
            var eventName = typeof(TEvent).Name;
            RemoveEvent(eventName,typeof(TEventHandler));
        }

        private void RemoveEvent(string eventName,Type eventHandlerType)
        {
            var subscription = _handlers[eventName].SingleOrDefault(s => s.HandlerType == eventHandlerType);
            _handlers[eventName].Remove(subscription);
            if (!_handlers[eventName].Any())
            {
                _handlers.Remove(eventName);
                var eventType = _eventTypes.SingleOrDefault(e => e.Name == eventName);
                if (eventType != null)
                {
                    _eventTypes.Remove(eventType);
                }
                OnEventRemoved?.Invoke(this, eventName);
            }
        }

        #region Private Methods

        void AddSubscription<TEventHandler>(string eventName,bool isDynamic)
        {
            if (!HasSubscriptionsForEvent(eventName))
            {
                _handlers.Add(eventName,new List<Subscription>());
            }
            if(_handlers[eventName].Any(s => s.HandlerType == typeof(TEventHandler))){
                throw new ArgumentException(
                    $"Handler Type {typeof(TEventHandler).Name} already registered for '{eventName}'", nameof(TEventHandler));
            }
            if (isDynamic)
            {
                _handlers[eventName].Add(Subscription.Dynamic(typeof(TEventHandler)));
            }
            else
            {
                _handlers[eventName].Add(Subscription.Typed(typeof(TEventHandler)));
            }
        }
        #endregion
    }
}
