
using App.Api.Controllers;
using App.Application.Customers.Commands.CreateCustomer;
using App.Application.Features.User.Requests.Commands;
using App.Contracts.Auth;
using App.Contracts.Customers;
using App.Contracts.Keycloak;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;


namespace Post.Cmd.Api.Controllers
{
    [ApiController]
    [Route("api/v1")]

    public class AuthControllery : ApiController
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthControllery(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin authLogin)
        {

           
            var command = _mapper.Map<GetAuthCommand>((authLogin));
            var result = await _mediator.Send(command);

            return result.Match
               (response => Ok(response),
               errors => Problem(errors)
               );
        }
    }
}