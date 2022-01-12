using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogBrandService
{
    Task<int?> CreateBrandAsync(string brand);
    Task<int?> DeleteBrandAsync(int id);
    Task<int?> DeleteBrandByTitleAsync(string brand);
    Task<int?> UpdateBrandAsync(int id, string brand);
    Task<CatalogBrandDto?> GetByBrandAsync(string brand);
    Task<CatalogBrandDto?> GetBrandByIdAsync(int id);
    Task<IEnumerable<CatalogBrandDto>?> GetBrandsAsync();
    Task<PaginatedItemsResponse<CatalogBrandDto>?> GetBrandsByPageAsync(int pageSize, int pageIndex);
}
