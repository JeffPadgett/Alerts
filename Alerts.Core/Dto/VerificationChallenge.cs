namespace Alerts.Core.Dto
{
    public class VerificationChallenge
    {
        public string Challenge { get; set; } = string.Empty;
        public Subscription Subscription { get; set; } = new();
    }
}
