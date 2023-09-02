using System.Text.Json.Serialization;

namespace Alerts.Core.Dto
{

    public class Subscription
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("version")]
        public string Version { get; set; }
        [JsonPropertyName("cost")]
        public int Cost { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        public Condition Condition { get; set; }
        public Transport Transport { get; set; }
    }

}
