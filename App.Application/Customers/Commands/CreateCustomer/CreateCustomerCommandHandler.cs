using App.Application.Interfaces.Persistance;
using App.Domain.Customers;
using ErrorOr;
using MediatR;

namespace App.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ErrorOr<Customer>>
    {

        private readonly ICustomerRepository _customerRepository;
 
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ErrorOr<Customer>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {     
         
            var customer = Customer.Create(request.Term,request.Title,request.FirstName,request.LastName,request.DateOfBirth,request.Mobile,request.Email, request.AmountRequired);

            await _customerRepository.Add(customer);       
            return customer;
        }

    
    }
}
