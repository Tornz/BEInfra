using MediatR;

using App.Application.Features.User.Requests.Commands;

using App.Application.Interfaces.Persistance;

using System.Net;
using App.Domain.Common.Errors;
using ErrorOr;
using App.Contracts.Keycloak;

using Newtonsoft.Json;

namespace App.Application.Features.User.Handlers.Commands
{
    public class GetAuthCommandHandler : IRequestHandler<GetAuthCommand,ErrorOr<KeycloakCredential>>
    {

        private readonly IIdentityServerRespository _identityServerRespository;
        public GetAuthCommandHandler(IIdentityServerRespository identityServerRespository)
        {
            _identityServerRespository = identityServerRespository;       
        }
        public async Task<ErrorOr<KeycloakCredential>> Handle(GetAuthCommand request, CancellationToken cancellationToken)
        {     
            var response = await _identityServerRespository.UserAuthentication(request.Username, request.Password);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {

                return Errors.Login.LoginEmailValidation;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {

                return Errors.Login.LoginUnauthorized;
            }
            else
            {
                var contents = await response.Content.ReadAsStringAsync();
                var credential = JsonConvert.DeserializeObject<KeycloakCredential>(contents);
                return credential;
            }           
        }
    
    }
}
