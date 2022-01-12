namespace Catalog.Host.Models.Response;

public class CreateProductResponse<T>
{
    public T Id { get; set; } = default!;
}
