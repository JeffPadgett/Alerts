using Alerts.Api.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Alerts.Test
{
    public class KeyVaultIntegrationTests
    {
        private readonly IKeyVaultService _keyVaultService;
        public KeyVaultIntegrationTests()
        {
            ServiceCollection serviceColleciton = new();
            serviceColleciton.AddSingleton<IKeyVaultService, KeyVaultService>();

            var serviceProvider = serviceColleciton.BuildServiceProvider();
            _keyVaultService = serviceProvider.GetRequiredService<IKeyVaultService>();
        }

        //[Fact]
        //public void Test_KeyVault_Can_Retrieve_Secrets_And_Connect()
        //{
        //    var secretValue = _keyVaultService.GetSecret("TestSecret");

        //    Assert.NotNull(secretValue);
        //    Assert.NotEmpty(secretValue);
        //}
    }
}
