using System.Text.Json.Serialization;

namespace Api.Controllers.Identity
{
    public class ImpersonationRequest
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }
    }
}