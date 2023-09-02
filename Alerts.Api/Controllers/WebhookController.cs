using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Alerts.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TwitchWebHookController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> ReceiveWebhook()
        {
            if (Request.Headers.ContainsKey("Twitch-Eventsub-Message-Type"))
            {
                string messageType = Request.Headers["Twitch-Eventsub-Message-Type"];
                if (messageType == "webhook_callback_verification")
                {
                    
                }
            }

        }

        private async Task<string> VerifySignature(HttpRequest req)
        {
            using StreamReader reader = new StreamReader(Request.Body);
            string requestBody = await reader.ReadToEndAsync();

            ChallengeJson callbackJson = JsonSerializer.Deserialize<ChallengeJson>(requestBody);


        }
    }
    
}