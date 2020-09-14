namespace Core.Models.ApplicationResources
{
    public class BaseResourceResponse 
    {
        public BaseResourceResponse()
        {            
        }
        public BaseResourceResponse(string errorMessage,bool success = false)
        {
            Message = errorMessage;
            Success = success;
        }
        public BaseResourceResponse(BaseResourceResponse response) : this(response?.Message ?? "A unexpected error occurred", response?.Success ?? false)
        {

        }
        public string Message { get; set; }
        public bool Success { get; set; }

        public static readonly BaseResourceResponse DefaultSuccessResponse = new BaseResourceResponse("Operation executed successfully",true);
        public static readonly BaseResourceResponse DefaultFailureResponse = new BaseResourceResponse("A unexpected error occurred", false);
        public static BaseResourceResponse GetFailureResponseWithMessage(string message)
        {
            return new BaseResourceResponse(message);
        }
        public static BaseResourceResponse<T> GetDefaultFailureResponseWithObject<T>(T resultObject)
        {
            return new BaseResourceResponse<T>(BaseResourceResponse.DefaultFailureResponse, resultObject);
        }
        public static BaseResourceResponse<T> GetDefaultSuccessResponseWithObject<T>(T resultObject)
        {
            return new BaseResourceResponse<T>(BaseResourceResponse.DefaultSuccessResponse, resultObject);
        }
    }
    public class BaseResourceResponse<T>  : BaseResourceResponse
    {
        public BaseResourceResponse() : base()
        {

        }
        public BaseResourceResponse(string errorMessage,T resultObject, bool success = true) : base(errorMessage,success)
        {
            ResultObject = resultObject;
        }
        public BaseResourceResponse(BaseResourceResponse response,T resultObject) : base(response)
        {
            ResultObject = resultObject;
        }
        public T ResultObject { get; set; }
        
    }
}
