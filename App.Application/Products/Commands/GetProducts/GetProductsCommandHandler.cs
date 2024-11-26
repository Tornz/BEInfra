using App.Application.Customers.Commands.CreateCustomer;
using App.Application.Interfaces.Caching;
using App.Application.Interfaces.Persistance;
using App.Contracts.Products;
using App.Domain.Products;
using ErrorOr;
using MapsterMapper;
using MediatR;


namespace App.Application.Products.Commands.GetProducts
{
    public class GetProductsCommandHandler : IRequestHandler<GetProductCommand, ErrorOr<IEnumerable<ProductDto>>>
    {

        private readonly IProductRepository _productRepository;
        private readonly IRedisCacheService _redisCacheService;
        private readonly IMapper _mapper;

        public GetProductsCommandHandler(IProductRepository productRepository, IRedisCacheService redisCacheService, IMapper mapper)
        {
            _productRepository = productRepository;
            _redisCacheService = redisCacheService;
            _mapper = mapper;
        }

        public async Task<ErrorOr<IEnumerable<ProductDto>>> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            //var result = await _redisCacheService.GetData<IEnumerable<ProductDto>>("products");
            //if (result is not null)
            //{

            //    return result.ToList();
            //}
            var data = await _productRepository.GetAll(request.pagination);
            var result = _mapper.Map<IEnumerable<ProductDto>>((data));
            //_redisCacheService.SetData("products", result);
            return result.ToList();
        }


    }
}
