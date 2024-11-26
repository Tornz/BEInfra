using App.Application.Interfaces.Persistance;
using App.Contracts.Pagination;
using App.Domain.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {


        private readonly AppDbContext _dbContext;
        IHttpContextAccessor _httpContextAccessor;

        public ProductRepository(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor; 
        }

        public async Task Add(Product product)
        {
            //await Task.CompletedTask;
             await _dbContext.AddAsync(product);
             _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Product>> GetAll(PaginationDTO pagination)
        {
            var queryable = _dbContext.Products.AsQueryable();
            await _httpContextAccessor.HttpContext!.InsertPaginationParamenterInResponseHeader(queryable);
            return await queryable.OrderBy(a=>a.Name).Paginate(pagination).ToListAsync();
        }
    }
}
