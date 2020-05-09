using System.Collections.Generic;

namespace Core.Models
{
    public class BaseResult<T> 
    {
        public IEnumerable<string> Errors { get; set; } = new List<string>();
        public bool Success { get; set; }
        public T Value { get; set; }
    }
}