

using App.Application.Customers.Commands.CreateCustomer;
using App.Application.Customers.Commands.UpdateCustomer;
using App.Contracts.Customers;
using App.Domain.Customers;
using Mapster;


namespace App.Api.Mapping
{
    public class CustomerMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config) {
            config.NewConfig<(CreateCustomerRequest Request, string HostId), CreateCustomerCommand>()                   
                   .Map(dest => dest, src => src.Request);

            config.NewConfig<(CreateCustomerRequest Request, string Id), UpdateCustomerCommand>()
              .Map(dest => dest, src => src.Request);

            config.NewConfig<Customer, CustomerReponse>()
                   .Map(dest => dest.Id, src => src.Id.Value)
                   .Map(dest => dest, src => src);
                  
        }
    }
}
