using MVC.ViewModels;

namespace MVC.Services.Interfaces;

public interface ICatalogService
{
    Task<IEnumerable<SelectListItem>> GetBrandsAsync();

    Task<Catalog> GetCatalogItemsAsync(int page, int take, int? brand, int? type);

    Task<IEnumerable<SelectListItem>> GetTypesAsync();
}
