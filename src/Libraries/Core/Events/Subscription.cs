using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Events
{
    public class Subscription
    {
        public bool IsDynamic { get; }
        public Type HandlerType { get; }

        private Subscription(bool isDynamic, Type handlerType)
        {
            IsDynamic = isDynamic;
            HandlerType = handlerType;
        }

        public static Subscription Dynamic(Type handlerType) => new Subscription(true, handlerType);
        public static Subscription Typed(Type handlerType) => new Subscription(false, handlerType);
    }
}
