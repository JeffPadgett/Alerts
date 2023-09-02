using System.Text.Json.Serialization;

namespace Alerts.Core.Models
{
    public class Condition
    {
        [JsonPropertyName("broadcaster_user_id")]
        public string BroadcasterUserId { get; set; }
        [JsonPropertyName("to_broadcaster_user_id")]
        public string ToBroadcasterUserId { get; set; }
        [JsonPropertyName("from_broadcaster_user_id")]
        public string FromBroadcasterUserId { get; set; }
    }
}
