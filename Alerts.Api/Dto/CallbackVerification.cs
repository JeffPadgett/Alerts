using Alerts.Core.Dto;
using System.Text.Json.Serialization;

namespace Alerts.Api.Dto
{
    public class CallbackVerification
    {

        [JsonPropertyName("challenge")]
        public string Challenge { get; set; }

        public Subscription Subscription { get; set; }

    }
}
