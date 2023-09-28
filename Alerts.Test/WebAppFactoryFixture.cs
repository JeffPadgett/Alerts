//Think of this as basically our DI container - We are creating a "Fixture" that can be utilized in our test classes throughout the xunit project. 
using Alerts.Api.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Alerts.Test
{
    public class WebAppFactoryFixture : IDisposable
    {
        public WebApplicationFactory<Program> Factory { get; }
        public IKeyVaultService KeyVaultService { get; private set; }

        public WebAppFactoryFixture()
        {
            Factory = new WebApplicationFactory<Program>();

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
            KeyVaultService = serviceProvider.GetRequiredService<IKeyVaultService>();
        }

        public void Dispose()
        {
            Factory.Dispose();
        }
    }

    //This class is literally just to create the definition so we can add it. See VerifyHandshakeSignatureIntegrationAPiTest.cs file. 
    //You will see that we are using the Colleciton Anotation. 
    [CollectionDefinition("WebAppFactory collection")]
    public class WebAppFactoryCollection : ICollectionFixture<WebAppFactoryFixture>
    {
        // This class has no code and is never instantiated. 
        // Its purpose is to be the place to apply [CollectionDefinition] and all the ICollectionFixture<> interfaces.
    }
}
