

using App.Domain.Customers;
using App.Domain.Customers.ValueObjects;

namespace App.Application.Interfaces.Persistance
{
    public interface ICustomerRepository
    {

        Task Add(Customer customer);
       Task<Customer> GetUserById(CustomerId id);
    }
}
