//Put secrets here from KV, this is DI'ed in the application and accessed when needed, that way there is only one call during the inital load of the app and no latency.

namespace Alerts.Api.Services
{
    public class AppSecrets
    {
        public string? EventSubSecret { get; set; }
    }

}
