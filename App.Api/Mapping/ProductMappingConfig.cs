


using App.Contracts.Products;
using App.Domain.Products;
using Mapster;


namespace App.Api.Mapping
{
    public class ProductMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config) {


            config.NewConfig<ProductDto, ProductReponse>()
                   .Map(dest => dest.Id, src => src.Id.Value)
                    .Map(dest => dest.Name, src => src.Name)
                    .Map(dest => dest.InterestRate, src => src.InterestRate);

      
        }
    }
}
