namespace Catalog.Host.Models.Requests;

public class TPaginatedItemsRequest<T>
{
    public int PageIndex { get; set; }

    public int PageSize { get; set; }

    public T Item { get; set; } = default(T)!;
}
