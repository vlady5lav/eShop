using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogBrandRepository
{
    Task<int?> AddAsync(string brand);

    Task<int?> DeleteAsync(int id);

    Task<int?> DeleteByTitleAsync(string brand);

    Task<IEnumerable<CatalogBrand>?> GetBrandsAsync();

    Task<CatalogBrand?> GetByBrandIdAsync(int id);

    Task<CatalogBrand?> GetByBrandTitleAsync(string brand);

    Task<PaginatedItems<CatalogBrand>?> GetByPageAsync(int pageSize, int pageIndex);

    Task<int?> UpdateAsync(int id, string brand);
}
