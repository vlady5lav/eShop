using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogProductRepository
{
    Task<int?> AddAsync(string name, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string? description, string? pictureFileName);
    Task<int?> DeleteAsync(int id);
    Task<int?> UpdateAsync(int id, string? name, decimal? price, int? availableStock, int? catalogBrandId, int? catalogTypeId, string? description, string? pictureFileName);
    Task<CatalogProduct?> GetByIdAsync(int id);
    Task<IEnumerable<CatalogProduct>?> GetProductsAsync();
    Task<PaginatedItems<CatalogProduct>?> GetByBrandIdAsync(int id, int pageSize, int pageIndex);
    Task<PaginatedItems<CatalogProduct>?> GetByBrandTitleAsync(string brand, int pageSize, int pageIndex);
    Task<PaginatedItems<CatalogProduct>?> GetByPageAsync(int pageSize, int pageIndex);
    Task<PaginatedItems<CatalogProduct>?> GetByTypeIdAsync(int id, int pageSize, int pageIndex);
    Task<PaginatedItems<CatalogProduct>?> GetByTypeTitleAsync(string type, int pageSize, int pageIndex);
}
