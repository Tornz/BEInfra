



using App.Application.Products.Commands.GetProducts;
using App.Contracts.Products;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/v1/products")]
    public class ProductController : ApiController
    {

        private readonly IMapper _mapper;

        private readonly ISender _mediator;
        public ProductController(IMapper mapper, ISender mediator) { 
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {    
            var getProductResult = await _mediator.Send(new GetProductCommand() { });            
            return getProductResult.Match
                (products => Ok(_mapper.Map<IEnumerable<ProductReponse>>(products)),
                errors => Problem(errors)
                );
        }

  
    }
}
