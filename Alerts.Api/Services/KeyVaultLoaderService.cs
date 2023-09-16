namespace Alerts.Api.Services
{
    public class KeyVaultLoaderService : IHostedService
    {
        private readonly IKeyVaultService _keyVaultService;
        private readonly AppSecrets _appSecrets;

        public KeyVaultLoaderService(IKeyVaultService keyVaultService, AppSecrets appSecrets)
        {
            _keyVaultService = keyVaultService;
            _appSecrets = appSecrets;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Here, populate the _appSecrets with the values from Key Vault.
            string? secretValue = _keyVaultService.GetSecret("EventSubSecret");
            _appSecrets.EventSubSecret = secretValue;

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
