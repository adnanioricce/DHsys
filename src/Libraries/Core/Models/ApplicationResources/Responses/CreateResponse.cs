using System.Collections.Generic;

namespace Core.Models.ApplicationResources.Responses
{
    //!
    public class CreateResponse : BaseResourceResponse
    {        
        public int CreatedWithSuccessCount { get; set; }
        public int FailedToCreateCount { get; set; }        
    }
}
