using Alerts.Api.Services;
using Alerts.Core.Dto;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Alerts.Test
{
    public class VerifyHandshakeSignatureIntegrationApiTest : IClassFixture<WebAppFactoryFixture>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly IKeyVaultService _keyVaultService;

        public VerifyHandshakeSignatureIntegrationApiTest(WebAppFactoryFixture fixture)
        {
            _factory = fixture.Factory;
            _keyVaultService = fixture.KeyVaultService;
        }

        [Fact]
        public async Task VerifySignature_ValidRequest_ReturnsCorrectSignature()
        {
            //Create Test Payload
            VerificationChallenge verificationChallenge = new VerificationChallenge()
            {
                Challenge = "pogchamp-kappa-360noscope-vohiyo",
                Subscription = new()
            };
            string jsonPayload = JsonSerializer.Serialize(verificationChallenge);

            //Create RequestMessage
            string messageId = Guid.NewGuid().ToString();
            string timestamp = DateTime.UtcNow.ToString("o");  // ISO 8601 format
            string signature = GenerateTwitchSignature(messageId, timestamp, jsonPayload, _keyVaultService.GetSecret("EventSubSecret"));

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/api/TwitchWebHook");
            requestMessage.Headers.Add("Twitch-Eventsub-Message-Type", "webhook_callback_verification");
            requestMessage.Headers.Add("Twitch-Eventsub-Message-Id", messageId);
            requestMessage.Headers.Add("Twitch-Eventsub-Message-Timestamp", timestamp);
            requestMessage.Headers.Add("Twitch-Eventsub-Message-Signature", signature);
            requestMessage.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            //Send Simulated Request Challenge to webhook controller. 
            var client = _factory.CreateClient();
            var response = await client.SendAsync(requestMessage);

            response.EnsureSuccessStatusCode();
        }

        private string GenerateTwitchSignature(string messageId, string timestamp, string body, string secret)
        {
            var combinedMessage = $"{messageId}{timestamp}{body}";
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(combinedMessage));
            return "sha256=" + BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}
