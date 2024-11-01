

namespace App.Contracts.Keycloak
{
    public class KeyCloakSettings
    {
        public string KeycloakTokenUrl { get; set; } = string.Empty;

        public string KeycloakUrlRealm { get; set; } = string.Empty;
        public string KeycloakUserUrl { get; set; } = string.Empty;
        public string KeycloakPublicUserUrl { get; set; } = string.Empty;
        public string KeycloakUrl { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string ClientIdCredential { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
        public string GrandType { get; set; } = string.Empty;
        public string GrandTypePassword { get; set; } = string.Empty;

    }
}
