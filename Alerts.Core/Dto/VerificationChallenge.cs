using System.Text.Json.Serialization;

namespace Alerts.Core.Dto
{
    public class VerificationChallenge
    {
        [JsonPropertyName("challenge")]
        public string Challenge { get; set; } = string.Empty;
        public Subscription Subscription { get; set; } = new();
    }
}
