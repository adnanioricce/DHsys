using System;

namespace Core.Events
{
   public abstract class Event
   {        
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime DateCreated { get; } = DateTime.UtcNow;
   }
}
