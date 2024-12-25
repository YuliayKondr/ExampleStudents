using System.Data;
using AutoMapper;
using ExampleApplication.DTO;
using ExampleDomen.Models;
using ExampleInfrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExampleMinimalApi.Handlers;

public class QueryProductsHandler : IRequestHandler<QueryProductsRequest, IReadOnlyCollection<ProductDto>>
{
    private readonly IRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public QueryProductsHandler(IRepository<Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<ProductDto>> Handle(QueryProductsRequest request, CancellationToken cancellationToken)
    {
        Product[] products = await _productRepository.Queryable().AsNoTracking().Include(x => x.Category).ToArrayAsync(cancellationToken);

        IReadOnlyCollection<ProductDto> results = products.Select(x => _mapper.Map<ProductDto>(x)).ToArray();

        return results;
    }
}