using Functional.Option;

namespace Core.Models.Results
{
    public class Error<T> where T : new()
    {
        public Error(string code,string message,bool showToUser)
        {
            Code = code;
            Message = message;
            ShowToUser = showToUser;
            ErrorObject = Option.None;
        }
        public Error(string code,string message) : this(code,message,false){}
        public Error(string message) : this("",message,false){}
        public Error(string message,bool showToUser) : this("",message,showToUser){}
        ///<summary>
        /// Get or Set a code to identify the error
        ///</summary>
        public string Code { get; set; }
        ///<summary>
        /// Get or Set the message of the error
        ///</summary>
        public string Message { get; set; }
        ///<summary>
        /// Get or set a flag to determine if this error should be visible by the users of the system
        ///</summary>
        public bool ShowToUser { get; set; } = false;
        /// <summary>
        /// Get or set a object with additional information about the error
        /// </summary>
        public virtual Option<T> ErrorObject { get; set; } = Option.None;
    }
    public class Error : Error<object>
    {
        public Error(string code,string message,bool showToUser) : base(code,message,showToUser)
        {            
            ErrorObject = Option.None;
        }
        public Error(string message) : base(message){}
    }
}