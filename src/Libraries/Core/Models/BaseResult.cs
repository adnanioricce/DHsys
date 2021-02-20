using System.Collections.Generic;

namespace Core.Models
{
    //!Possible replication of Application.Models.ApplicationResources.BaseResourceResponse
    public class BaseResult<T> 
    {
        public BaseResult()
        {

        }
        public static BaseResult<T> CreateSuccessResult(string successMessage, T value)
        {
            return new BaseResult<T>
            {
                Success = true,
                SuccessMessage = successMessage,
                Value = value
            };
        }
        public static BaseResult<T> CreateFailResult(IEnumerable<string> errors,T value)
        {
            return new BaseResult<T>
            {
                Value = value,
                Errors = errors,
                Success = false
            };
        }
        public IEnumerable<string> Errors { get; set; } = new List<string>();
        public bool Success { get; set; }
        public string SuccessMessage { get; set; }
        public T Value { get; set; }     
        
    }    
}