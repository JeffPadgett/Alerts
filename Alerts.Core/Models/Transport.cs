using System.Text.Json.Serialization;

namespace Alerts.Core.Models
{
    public class Transport
    {
        [JsonPropertyName("method")]
        public string Method { get; set; }
        [JsonPropertyName("callback")]
        public string Callback { get; set; }
        [JsonPropertyName("secret")]
        public string Secret { get; set; }
    }
}
