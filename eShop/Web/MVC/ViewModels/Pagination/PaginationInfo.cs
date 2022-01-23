namespace MVC.ViewModels.Pagination;

public class PaginationInfo
{
    public int ActualPage { get; set; }

    public int ItemsPerPage { get; set; }

    public string Next { get; set; } = null!;

    public string Previous { get; set; } = null!;

    public int TotalItems { get; set; }

    public int TotalPages { get; set; }
}
