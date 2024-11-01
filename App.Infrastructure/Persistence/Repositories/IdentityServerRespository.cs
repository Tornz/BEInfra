using App.Application.Interfaces.Persistance;
using App.Contracts.Keycloak;
using Microsoft.Extensions.Options;

namespace App.Infrastructure.Persistence.Repositories
{
    public class IdentityServerRespository : IIdentityServerRespository
    {

        private readonly IOptions<KeyCloakSettings> _keyCloakSettings;
        public IdentityServerRespository(IOptions<KeyCloakSettings> keyCloakSettings)
        {
            _keyCloakSettings = keyCloakSettings;

        }
        public async Task<HttpResponseMessage> UserAuthentication(string Username, string Password)
        {
            string endPoint = _keyCloakSettings.Value.KeycloakTokenUrl;
            var client = new HttpClient();
            var data = new[]
            {
                        new KeyValuePair<string, string>("username", Username),
                        new KeyValuePair<string, string>("password",  Password),
                        new KeyValuePair<string, string>("grant_type", _keyCloakSettings.Value.GrandTypePassword),
                        new KeyValuePair<string, string>("client_id", _keyCloakSettings.Value.ClientId),
                    };
            Console.WriteLine("keycloak login:" + Username);
            var response = await client.PostAsync(endPoint, new FormUrlEncodedContent(data));
            Console.WriteLine("keycloak Response code for " + Username + ":" + response.StatusCode.ToString());
            return response;
        }
    }
}
