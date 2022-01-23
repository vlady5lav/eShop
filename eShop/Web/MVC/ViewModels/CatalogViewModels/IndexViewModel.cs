using MVC.ViewModels.Pagination;

namespace MVC.ViewModels.CatalogViewModels;

public class IndexViewModel
{
    public int? BrandFilterApplied { get; set; }

    public IEnumerable<SelectListItem> Brands { get; set; } = null!;

    public IEnumerable<CatalogItem> CatalogItems { get; set; } = null!;

    public PaginationInfo PaginationInfo { get; set; } = null!;

    public IEnumerable<SelectListItem> Types { get; set; } = null!;

    public int? TypesFilterApplied { get; set; }
}
