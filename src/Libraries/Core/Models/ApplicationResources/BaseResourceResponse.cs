namespace Core.Models.ApplicationResources
{
    public class BaseResourceResponse
    {
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
    }
    public class BaseResourceResponse<T>  : BaseResourceResponse
    {
        public T ResultObject { get; set; }
        
    }
}
