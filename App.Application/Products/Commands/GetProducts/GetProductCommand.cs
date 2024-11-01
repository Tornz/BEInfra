


using App.Contracts.Products;

using ErrorOr;
using MediatR;

namespace App.Application.Products.Commands.GetProducts
{   
   public record class GetProductCommand() :IRequest<ErrorOr<IEnumerable<ProductDto>>>;


}
