using App.Contracts.Keycloak;
using ErrorOr;
using MediatR;


namespace App.Application.Features.User.Requests.Commands
{


    public record class GetAuthCommand(
         string Username,
         string Password
       
 ) : IRequest<ErrorOr<KeycloakCredential>>;
}
