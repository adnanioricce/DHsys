using Core.Events;
using System;

namespace Queue
{
    public class TransactionEvent : Event
    {        
        public string From { get; }
        public string To { get; }
        public decimal Value { get; }
        public TransactionEvent(string from,string to,decimal value)
        {
            From = from;
            To = to;
            Value = value;            
        }
    }
}
