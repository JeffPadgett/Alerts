using Alerts.Api.Services;
using Alerts.Core.Dto;
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
        private const string WebhookCallbackVerification = "webhook_callback_verification";
        private const string Sha256Prefix = "sha256=";

        private readonly AppSecrets _secrets;

        public TwitchWebHookController(AppSecrets secrets)
        {
            _secrets = secrets;
        }

        [HttpPost]
        public async Task<IActionResult> ReceiveWebhook()
        {
            if (Request.Headers["Twitch-Eventsub-Message-Type"] == WebhookCallbackVerification &&
                await VerifySignature(Request) is string signature &&
                !string.IsNullOrEmpty(signature))
            {
                return Ok(signature);
            }

            return BadRequest("Failed verification.");
        }

        private async Task<string?> VerifySignature(HttpRequest req)
        {
            using StreamReader reader = new StreamReader(Request.Body);
            string requestBody = await reader.ReadToEndAsync();

            VerificationChallenge verificationChallenge = JsonSerializer.Deserialize<VerificationChallenge>(requestBody)!;
            string hmacMessage = req.Headers["Twitch-Eventsub-Message-Id"] + req.Headers["Twitch-Eventsub-Message-Timestamp"] + requestBody;

            var expectedSignature = Sha256Prefix + CreateHmacHash(hmacMessage, _secrets.EventSubSecret!);

            return expectedSignature == req.Headers["Twitch-Eventsub-Message-Signature"] ? verificationChallenge.Challenge : null;
        }

        private string CreateHmacHash(string data, string key)
        {
            var keybytes = Encoding.UTF8.GetBytes(key);
            var dataBytes = Encoding.UTF8.GetBytes(data);

            using var hmac = new HMACSHA256(keybytes);
            var hmacBytes = hmac.ComputeHash(dataBytes);

            return BitConverter.ToString(hmacBytes).Replace("-", "").ToLower();
        }
    }
}