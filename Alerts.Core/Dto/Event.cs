using System.Text.Json.Serialization;

namespace Alerts.Core.Dto
{
    public class Event
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }
        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; }
        [JsonPropertyName("broadcaster_user_id")]
        public string BroadcasterUserId { get; set; }
        [JsonPropertyName("broadcaster_user_login")]
        public string BroadcasterUserLogin { get; set; }
        [JsonPropertyName("broadcaster_user_name")]
        public string BroadcasterUserName { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("started_at")]
        public DateTime StartedAt { get; set; }
        [JsonPropertyName("from_broadcaster_user_id")]
        public string FromBroadCasterUserId { get; set; }
        [JsonPropertyName("from_broadcaster_user_login")]
        public string FromBroadcasterUserLogin { get; set; }
        [JsonPropertyName("from_broadcaster_user_name")]
        public string FromBroadcasterUserName { get; set; }
        [JsonPropertyName("to_broadcaster_user_id")]
        public string ToBroadCasterUserId { get; set; }
        [JsonPropertyName("to_broadcaster_user_login")]
        public string ToBroadcasterUserLogin { get; set; }
        [JsonPropertyName("to_broadcaster_user_name")]
        public string ToBroadcasterUserName { get; set; }
        [JsonPropertyName("viewers")]
        public int ViewerCount { get; set; }
    }
}
