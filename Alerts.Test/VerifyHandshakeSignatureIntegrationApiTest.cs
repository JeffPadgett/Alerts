using Alerts.Core.Dto;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;
using System.Text.Json;

namespace Alerts.Test
{
    [Collection("WebAppFactory collection")]
    public class VerifyHandshakeSignatureIntegrationApiTest
    {
        private readonly WebApplicationFactory<Program> _factory;

        public VerifyHandshakeSignatureIntegrationApiTest(WebAppFactoryFixture fixture)
        {
            _factory = fixture.Factory;
        }

        [Fact]
        public async Task Test_Verify_Signature_Responds_With_Correct_Signature()
        {
            //Create Test Payload
            VerificationChallenge verificationChallenge = new VerificationChallenge()
            {
                Challenge = "pogchamp-kappa-360noscope-vohiyo",
                Subscription = new()
            };
            string jsonPayload = JsonSerializer.Serialize(verificationChallenge);

            //Create RequestMessage
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/api/TwitchWebHook");
            requestMessage.Headers.Add("Twitch-Eventsub-Message-Type", "webhook_callback_verification");
            requestMessage.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var client = _factory.CreateClient();
            var response = await client.SendAsync(requestMessage);

            response.EnsureSuccessStatusCode();

        }
    }
}
