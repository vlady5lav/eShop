namespace MVC.Models.Requests;

public class PaginatedItemsRequest<T>
    where T : notnull
{
    public Dictionary<T, int>? Filters { get; set; }

    public int PageIndex { get; set; }

    public int PageSize { get; set; }
}
