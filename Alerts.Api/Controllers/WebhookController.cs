using Alerts.Api.Dto;
using Alerts.Api.Services;
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
        private readonly AppSecrets _secrets;
        public TwitchWebHookController()
        {
            _secrets = new AppSecrets();
        }

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

            return Ok(); 
        }

        private async Task<string> VerifySignature(HttpRequest req)
        {
            using StreamReader reader = new StreamReader(Request.Body);
            string requestBody = await reader.ReadToEndAsync();

            CallbackVerification callbackVerification = JsonSerializer.Deserialize<CallbackVerification>(requestBody);
            string hmacMessage = req.Headers["Twitch-Eventsub-Message-Id"] + req.Headers["Twitch-Eventsub-Message-Timestamp"] + requestBody;

            var expectedSignature = "sha256=" + CreateHmacHash(hmacMessage, _secrets.EventSubSecret!);
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