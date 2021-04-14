using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Events
{
    public static class DomainEventHub
    {
        [ThreadStatic]
        private readonly static Dictionary<Type, object> _handlers = new Dictionary<Type, object>();
        public static void Subscribe<TEvent>(IDomainEventHandler<TEvent> handler) where TEvent : IDomainEvent
        {
            var type = typeof(IDomainEventHandler<TEvent>);
            if (_handlers.ContainsKey(type))
            {
                return;
            }
            _handlers.Add(type, handler);
        }        
        /// <summary>
        /// Execute handler of event type for given event object
        /// </summary>
        /// <typeparam name="TEvent">the type the handler support</typeparam>
        /// <param name="event">the event object to handle </param>
        /// <exception cref="InvalidOperationException"> exception is throwed if a event is given but no handler was subscribed</exception>
        public static void Dispatch<TEvent>(TEvent @event) where TEvent : IDomainEvent
        {
            if (!_handlers.ContainsKey(typeof(IDomainEventHandler<TEvent>)))
            {
                throw new InvalidOperationException($"there is no handler subscribed for the event {typeof(TEvent).Name}");
            }
            foreach (var handler in _handlers.Values.OfType<IDomainEventHandler<TEvent>>())
            {
                handler.Handle(@event);
            }            
        }
        private static IEnumerable<IDomainEventHandler<TEvent>> GetHandlersOf<TEvent>() where TEvent : IDomainEvent
        {
            var type = typeof(IDomainEventHandler<TEvent>);
            if (!_handlers.ContainsKey(type))
            {
                throw new InvalidOperationException($"there is no handler subscribed for the event {typeof(TEvent).Name}");
            }
            return (IEnumerable<IDomainEventHandler<TEvent>>)_handlers.Values.Where(i => i.GetType() == type);
        }
    }
}
