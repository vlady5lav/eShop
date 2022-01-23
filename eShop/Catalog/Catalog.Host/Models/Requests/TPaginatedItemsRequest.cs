namespace Catalog.Host.Models.Requests;

public class TPaginatedItemsRequest<T>
{
    public T? Item { get; set; }

    public int PageIndex { get; set; }

    public int PageSize { get; set; }
}
