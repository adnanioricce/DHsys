using System;

namespace Core.Results
{
    public record Error
    {
        public Error(string errorId,string message,bool showToUser = false)
        {

        }
        public string ErrorId { get; init; } 
        public string Message { get; init; } 
        public bool ShowToUser { get; init; }
        public DateTimeOffset CreatedAt { get; } = DateTimeOffset.UtcNow;
    }
}
