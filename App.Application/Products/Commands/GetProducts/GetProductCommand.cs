


using App.Contracts.Pagination;
using App.Contracts.Products;

using ErrorOr;
using MediatR;

namespace App.Application.Products.Commands.GetProducts
{   
   public record class GetProductCommand(PaginationDTO pagination) :IRequest<ErrorOr<IEnumerable<ProductDto>>>;


}
