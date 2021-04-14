using Core.Events;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Core.Tests
{
    public class EventHubTests
    {        
        [Fact(DisplayName = "subscribe a handler class of a domain event")]
        public void Given_event_data_type_without_behavior_When_subscribe_event_handler_Then_links_event_data_type_to_event_handler()
        {
            // Given            
            var @event = new TestDomainEvent();
            var eventHandler = new TestDomainEventHandler();                        
            // When
            DomainEventHub.Subscribe(eventHandler);
            DomainEventHub.Dispatch(@event);
            //Then
            Assert.Equal(1, @event.Count);            
        }
        [Fact(DisplayName = "only one handler can be registered for a given ")]
        public void Given_event_handler_When_try_to_subscribe_a_already_existing_handler_Then_no_change_should_be_done()
        {
            // Given            
            var @event = new TestDomainEvent();
            var eventHandler = new TestDomainEventHandler();
            // When
            DomainEventHub.Subscribe(eventHandler);
            DomainEventHub.Subscribe(eventHandler);
            DomainEventHub.Dispatch(@event);
            //Then
            Assert.Equal(1, @event.Count);
        }
        [Fact(DisplayName = "dispatch domain event with subscribed handler ")]
        public void Given_subscribed_change_on_event_hub_When_dispatch_event_Then_run_handle_method()
        {
            // Given
            var @event = new TestDomainEvent();
            DomainEventHub.Subscribe(new TestDomainEventHandler());            
            // When
            DomainEventHub.Dispatch(@event);
            // Then
            Assert.Equal(1,@event.Count);
        }
        [Fact(DisplayName = "if dispatch domain event without a subscribed handler, exception is throw")]
        public void Given_domain_event_with_no_handler_subscribed_When_try_to_dispatch_domain_event_Then_exception_will_be_throw()
        {
            // Given
            var @event = new TestDomainEventWithoutHandler();
            // When ... then
            Assert.Throws<InvalidOperationException>(() => DomainEventHub.Dispatch(@event));
        }
        [Fact(DisplayName = "two domain events being handled at same time should be handled without problem")]
        public void Given_domain_events_When_has_to_handle_two_domain_events_at_same_time_Then_each_one_should_be_handled_without_side_effects()
        {
            // Given
            var events = Enumerable.Range(1, 10).Select(e => new TestDomainEvent()).ToArray();
            var tasks = events.Select(e => new Task(() => e.Count++)).ToList();
            // When
            tasks.ForEach(task => task.Start());
            Task.WaitAll(tasks.ToArray());
            // Then
            Assert.True(events.All(e => e.Count == 1));
        }
    }    
    public class TestDomainEvent : IDomainEvent
    {
        public int Count { get; set; } = 0;
    }
    public class TestDomainEventHandler : IDomainEventHandler<TestDomainEvent>
    {
        public void Handle(TestDomainEvent @event)
        {
            @event.Count += 1;
        }
    }
    public class TestDomainEventWithoutHandler : IDomainEvent
    {

    }
}
