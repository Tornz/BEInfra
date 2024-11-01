


using App.Domain.Products;

namespace App.Application.Interfaces.Persistance
{
    public interface IIdentityServerRespository
    {        
         Task<HttpResponseMessage>  UserAuthentication(string Username, string Password);
    }
}
