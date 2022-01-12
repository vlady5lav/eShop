using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogProductRepository
{
    Task<int?> AddAsync(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task<int?> RemoveAsync(int id);
    Task<int?> UpdateAsync(int id, string? name, string? description, decimal? price, int? availableStock, int? catalogBrandId, int? catalogTypeId, string? pictureFileName);
    Task<CatalogProduct?> GetByIdAsync(int id);
    Task<IEnumerable<CatalogProduct>?> GetProductsAsync();
    Task<PaginatedItems<CatalogProduct>?> GetByBrandIdAsync(int id, int pageIndex, int pageSize);
    Task<PaginatedItems<CatalogProduct>?> GetByBrandAsync(string brand, int pageIndex, int pageSize);
    Task<PaginatedItems<CatalogProduct>?> GetByPageAsync(int pageIndex, int pageSize);
    Task<PaginatedItems<CatalogProduct>?> GetByTypeIdAsync(int id, int pageIndex, int pageSize);
    Task<PaginatedItems<CatalogProduct>?> GetByTypeAsync(string type, int pageIndex, int pageSize);
}
