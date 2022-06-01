using System.Text.Json.Serialization;

namespace Api.Controllers.Identity
{
    public class RefreshTokenRequest
    {
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }

}