

using App.Domain.Customers;
using ErrorOr;
using MediatR;

namespace App.Application.Customers.Commands.UpdateCustomer
{   
   public record class UpdateCustomerCommand(
            Guid Id            
    ) :IRequest<ErrorOr<Customer>>;


}
