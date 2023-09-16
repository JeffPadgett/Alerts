using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace Alerts.Api.Services
{
    public class KeyVaultService : IKeyVaultService
    {
        private readonly SecretClient _client;
        private readonly ILogger _logger;
        public KeyVaultService(IConfiguration config, ILogger<KeyVaultService> logger)
        {
            var vaultUri = config["KeyVault:Uri"];
            _client = new SecretClient(new Uri(vaultUri), new DefaultAzureCredential());
            _logger = logger;
        }

        public string GetSecret(string secretName)
        {
            try
            {
                var secret = _client.GetSecret(secretName);
                return secret.Value.Value;
            }
            catch(Exception ex)
            {
                _logger.LogCritical($"There was an error obtaining the value from the key vault.{ex.Message}");
                throw;
            }
        }
    }
}
