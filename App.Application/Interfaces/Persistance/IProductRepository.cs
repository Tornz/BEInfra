


using App.Domain.Products;

namespace App.Application.Interfaces.Persistance
{
    public interface IProductRepository
    {
         Task Add(Product product);
         Task<IEnumerable<Product>>  GetAll();
    }
}
