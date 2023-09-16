namespace Alerts.Api.Services
{
    public interface IKeyVaultService
    {
        string GetSecret(string secretName);
    }
}
