


using App.Application.Features.User.Handlers.Commands;
using App.Contracts.Auth;
using App.Contracts.Keycloak;
using App.Contracts.Products;
using App.Domain.Products;
using Mapster;


namespace App.Api.Mapping
{
    public class LoginMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config) {


            config.NewConfig<UserLogin, GetAuthCommandHandler>()
                   .Map(dest => dest, src => src);
                   

      
        }
    }
}
