using Alerts.Api.Services;

namespace Alerts.Test
{
    public class KeyVaultIntegrationTests : IClassFixture<WebAppFactoryFixture>
    {
        private readonly IKeyVaultService _keyVaultService;
        public KeyVaultIntegrationTests(WebAppFactoryFixture fixture)
        {
            _keyVaultService = fixture.KeyVaultService;
        }

        [Fact]
        public void Test_KeyVault_Can_Retrieve_Secrets_And_Connect()
        {
            var secretValue = _keyVaultService.GetSecret("TestSecret");

            Assert.NotNull(secretValue);
            Assert.NotEmpty(secretValue);
            Assert.Equal("Success", secretValue);
        }
    }
}
