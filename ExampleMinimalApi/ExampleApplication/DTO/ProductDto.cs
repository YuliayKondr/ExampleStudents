namespace ExampleApplication.DTO;

public sealed record ProductDto
{
    public int Id { get; init; }

    public string Name { get; init; }

    public string NameUa { get; init; }

    public string Category { get; init; }
}