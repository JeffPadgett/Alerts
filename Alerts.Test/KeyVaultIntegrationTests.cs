using Alerts.Api.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Alerts.Test
{
    public class KeyVaultIntegrationTests
    {
        private readonly IKeyVaultService _keyVaultService;
        public KeyVaultIntegrationTests()
        {
            var serviceCollection = new ServiceCollection();

            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddSingleton<IKeyVaultService, KeyVaultService>();
            serviceCollection.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();
            });

            var serviceProvider = serviceCollection.BuildServiceProvider();
            _keyVaultService = serviceProvider.GetRequiredService<IKeyVaultService>();
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
