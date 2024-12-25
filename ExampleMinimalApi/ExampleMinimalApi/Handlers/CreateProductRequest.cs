using ExampleApplication.Common;
using ExampleApplication.DTO;
using MediatR;
using Newtonsoft.Json;

namespace ExampleMinimalApi.Handlers;

public sealed class CreateProductRequest : IRequest<Result<ProductDto>>
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("name_ua")]
    public string NameUa { get; set; }

    [JsonProperty("category_id")]
    public int CategoryId { get; set; }
}