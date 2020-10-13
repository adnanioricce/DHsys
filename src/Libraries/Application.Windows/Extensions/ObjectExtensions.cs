using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace Application.Windows.Extensions
{
    public class ObjectExtensions
    {
        public static T CastObject<T>(object input)
        {
            if (input is JObject)
            {
                return (T)(JsonSerializer.Deserialize((input as JObject).ToString(), typeof(T)));
            }
            return (T)input;
        }
    }
}
