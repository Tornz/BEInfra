

using App.Domain.Customers;
using ErrorOr;
using MediatR;

namespace App.Application.Customers.Commands.CreateCustomer
{   
   public record class CreateCustomerCommand(
            string Term,
            string Title,
            string FirstName,
            string LastName,
            DateTime DateOfBirth,
            string Mobile,
            string Email,
            decimal AmountRequired
    ) :IRequest<ErrorOr<Customer>>;


}
