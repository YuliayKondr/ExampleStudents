using ExampleApplication.DTO;
using MediatR;

namespace ExampleMinimalApi.Handlers;

public sealed class QueryProductsRequest : IRequest<IReadOnlyCollection<ProductDto>>
{
}