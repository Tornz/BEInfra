using App.Application.Interfaces.Persistance;
using App.Domain.Customers;
using App.Domain.Customers.ValueObjects;
using Microsoft.EntityFrameworkCore;


namespace App.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {


        private readonly AppDbContext _dbContext;

        public CustomerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Customer customer)
        {
            //await Task.CompletedTask;
             await _dbContext.AddAsync(customer);
             _dbContext.SaveChanges();
        }
     
        public async Task<Customer> GetUserById(CustomerId id)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
