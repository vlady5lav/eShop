using MVC.ViewModels;

namespace MVC.Services.Interfaces;

public interface ICatalogService
{
    Task<IEnumerable<SelectListItem>> GetBrands();

    Task<Catalog> GetCatalogItems(int page, int take, int? brand, int? type);

    Task<IEnumerable<SelectListItem>> GetTypes();
}
