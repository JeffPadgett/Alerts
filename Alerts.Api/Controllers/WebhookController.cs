using Alerts.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
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

            return default; 

        }

        private async Task<string> VerifySignature(HttpRequest req)
        {
            using StreamReader reader = new StreamReader(Request.Body);
            string requestBody = await reader.ReadToEndAsync();

            CallbackVerification callbackVerification = JsonSerializer.Deserialize<CallbackVerification>(requestBody);
            string hmacMessage = req.Headers["Twitch-Eventsub-Message-Id"] + req.Headers["Twitch-Eventsub-Message-Timestamp"] + requestBody;

            var expectedSignature = "sha256=" + CreateHmacHash(hmacMessage, Environment.GetEnvironmentVariable("EventSubSecret"));//You are going to need to either put this in azure key vault later or set the env variable in an appservice once it's hosted in azure. 

            return default;
        }

        private string CreateHmacHash(string data, string key)
        {
            var keybytes = UTF8Encoding.UTF8.GetBytes(key);
            var dataBytes = UTF8Encoding.UTF8.GetBytes(data);

            using (var hmac = new HMACSHA256(keybytes))
            {
                var hmacBytes = hmac.ComputeHash(dataBytes);
                return BitConverter.ToString(hmacBytes).Replace("-", "").ToLower();
            }
        }
    }

}