using Newtonsoft.Json;
using System;

namespace Core.Results
{
    public record ExceptionError : Error
    {
        public Exception Exception { get; }
        public ExceptionError(Exception ex) : base(ex.GetType().Name,ex.Message,false)
        {
            Exception = ex;
        }
    }
}
