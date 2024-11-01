using App.Application.Interfaces.Persistance;
using App.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {


        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Product product)
        {
            //await Task.CompletedTask;
             await _dbContext.AddAsync(product);
             _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        }
    }
}
