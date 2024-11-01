using Microsoft.IdentityModel.Tokens;


namespace App.Api.Extensions.Authorization
{
    /// <summary>
    /// Authorization Middleware Options
    /// </summary>
    public class AuthorizationOptions
    {

        public int ReconnectDelayMinimum { get; set; } = 0;
        public int ReconnectDelayMaximum { get; set; } = 5;
        public TimeSpan[] AutomaticReconnect { get; set; } = new[] { TimeSpan.Zero, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(30) };
        public int RequestTimeout { get; set; } = 5000;
        public int MaximumRetries { get; set; } = 3;
        public int FrequencyCheck { get; set; } = 1000;
        public string Endpoint { get; set; }
        public string ClientId { get; set; }
        public TokenValidationParameters TokenValidationParameters { get; set; }
    }
}
