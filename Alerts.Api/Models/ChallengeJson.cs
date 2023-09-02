using Alerts.Core.Models;
using System.Text.Json.Serialization;

namespace Alerts.Api.Models
{
    public class ChallengeJson
    {

            [JsonPropertyName("challenge")]
            public string Challenge { get; set; }

            public Subscription Subscription { get; set; }
        }

    }
}
