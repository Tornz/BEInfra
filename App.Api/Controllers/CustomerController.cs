
using App.Application.Customers.Commands.CreateCustomer;
using App.Application.Customers.Commands.UpdateCustomer;
using App.Contracts.Customers;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/v1/customer")]
    public class CustomerController : ApiController
    {

        private readonly IMapper _mapper;

        private readonly ISender _mediator;
        public CustomerController(IMapper mapper, ISender mediator) { 
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerRequest request)
        {

            var command = _mapper.Map<CreateCustomerCommand>((request));
            var createCustomerResult = await _mediator.Send(command);
            
            return createCustomerResult.Match
                (customer => Ok(_mapper.Map<CustomerReponse>(customer)),
                errors => Problem(errors)
                );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id)
        {
            var createCustomerResult = await _mediator.Send(new UpdateCustomerCommand(id));

            return createCustomerResult.Match
                (customer => Ok(_mapper.Map<CustomerReponse>(customer)),
                errors => Problem(errors)
                );
        }


    }
}
