using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Queues
{
    public interface IEventHandler<TEvent>
    {
        Task Handle(TEvent @event);
    }
    public interface IDynamicEventHandler
    {        
        // em situações em que eu não quero fazer um handler especifico para cada evento
        Task Handle(dynamic @event);
    }
}
