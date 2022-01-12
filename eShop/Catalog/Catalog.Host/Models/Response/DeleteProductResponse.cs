namespace Catalog.Host.Models.Response;

public class DeleteProductResponse<T>
{
    public T Id { get; set; } = default!;
}
