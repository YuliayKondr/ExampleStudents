using ExampleApplication.Common;
using ExampleApplication.DTO;
using ExampleMinimalApi.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ExampleMinimalApi.Extensions;

namespace ExampleMinimalApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("all")]
        [Produces(typeof(IReadOnlyCollection<ProductDto>))]
        public async Task<IActionResult> GetProductsAsync()
        {
            IReadOnlyCollection<ProductDto> products = await _mediator.Send(new QueryProductsRequest());

            return Json(products);
        }

        [HttpPost("create")]
        [Produces(typeof(Result<ProductDto>))]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductRequest request)
        {
            Result<ProductDto> result = await _mediator.Send(request);

            return result.ToActionResult();
        }
    }
}