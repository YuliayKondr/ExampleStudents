using AutoMapper;
using ExampleApplication.Common;
using ExampleApplication.DTO;
using ExampleDomen.Models;
using ExampleInfrastructure.Repositories;
using ExampleInfrastructure.WorkDb;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExampleMinimalApi.Handlers;

public class CreateProductHandler : IRequestHandler<CreateProductRequest, Result<ProductDto>>
{
    private readonly IRepository<Product> _productRepository;
    private readonly IRepository<Category> _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductHandler(IRepository<Product> productRepository, IRepository<Category> categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ProductDto>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request?.Name) || string.IsNullOrEmpty(request.NameUa))
        {
            return Result.Error<ProductDto>("Name is required");
        }

        if (request.CategoryId == 0)
        {
            return Result.Error<ProductDto>("Category is required");
        }

        Category? category = await _categoryRepository.Queryable().AsNoTracking().FirstOrDefaultAsync(c => c.Id == request.CategoryId, cancellationToken);

        if (category == null)
        {
            return Result.Error<ProductDto>("Category not found");
        }

        Product product = new Product(request.Name, request.NameUa, request.CategoryId);

        _productRepository.Update(product);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _categoryRepository.Queryable().LoadAsync(cancellationToken);

        ProductDto productDto = _mapper.Map<ProductDto>(product);

        return Result<ProductDto>.Success(productDto);
    }
}