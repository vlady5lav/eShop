using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogTypeRepository
{
    Task<int?> AddAsync(string type);
    Task<int?> DeleteAsync(int id);
    Task<int?> DeleteByTitleAsync(string type);
    Task<int?> UpdateAsync(int id, string type);
    Task<CatalogType?> GetByTypeIdAsync(int id);
    Task<CatalogType?> GetByTypeTitleAsync(string type);
    Task<IEnumerable<CatalogType>?> GetTypesAsync();
    Task<PaginatedItems<CatalogType>?> GetByPageAsync(int pageSize, int pageIndex);
}
