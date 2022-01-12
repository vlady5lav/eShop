using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogTypeService
{
    Task<int?> CreateTypeAsync(string type);
    Task<int?> DeleteTypeAsync(int id);
    Task<int?> DeleteTypeByTitleAsync(string type);
    Task<int?> UpdateTypeAsync(int id, string type);
    Task<CatalogTypeDto?> GetByTypeAsync(string type);
    Task<CatalogTypeDto?> GetTypeByIdAsync(int id);
    Task<IEnumerable<CatalogTypeDto>?> GetTypesAsync();
    Task<PaginatedItemsResponse<CatalogTypeDto>?> GetTypesByPageAsync(int pageSize, int pageIndex);
}
