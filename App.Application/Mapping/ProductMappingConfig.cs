


using App.Contracts.Products;
using App.Domain.Products;
using Mapster;


namespace App.Application.Mapping
{
    public class ProductMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config) {
            config.NewConfig<ProductDto, Product>()
           .Map(dest => dest, src => src);
           
        }
    }
}
