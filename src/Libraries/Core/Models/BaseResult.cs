using System.Collections.Generic;

namespace Core.Models
{
    //!Possible replication of Application.Models.ApplicationResources.BaseResourceResponse
    public class BaseResult 
    {
        public IEnumerable<string> Errors { get; set; } = new List<string>();
        public bool Success { get; set; }
        public string SuccessMessage { get; set; }
        public virtual object Value { get; set; }
        public BaseResult()
        {
            
        }
        protected static BaseResult CreateSuccessResult(string message,object value)
        {
            return new BaseResult{
                Success = true,
                SuccessMessage = message,
                Value = value
            };
        }
        protected static BaseResult CreateFailResult(IEnumerable<string> errors,object value)
        {
            return new BaseResult{
                Errors = errors,
                Success = false,                
                Value = value
            };
        }
        public static BaseResult Failed(string[] messages) => BaseResult.CreateFailResult(messages,default(object));
        public static BaseResult Succeed(string message) => BaseResult.CreateSuccessResult(message,default(object));
    }
    public class BaseResult<T>  : BaseResult
    {
        public BaseResult()
        {

        }
        public static BaseResult<T> Succeed(string successMessage, T value)
        {
            return new BaseResult<T>
            {
                Success = true,
                SuccessMessage = successMessage,
                Value = value
            };
        }
        public static BaseResult<T> Failed(IEnumerable<string> errors,T value)
        {
            return new BaseResult<T>
            {
                Value = value,
                Errors = errors,
                Success = false
            };
        }
        public new T Value; 
        
    }    
}