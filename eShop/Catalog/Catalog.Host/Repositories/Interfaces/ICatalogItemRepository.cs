using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task<int?> AddAsync(
    string name,
    decimal price,
    int availableStock,
    int catalogBrandId,
    int catalogTypeId,
    string? description,
    string? pictureFileName);

    Task<int?> DeleteAsync(
        int id);

    Task<PaginatedItems<CatalogItem>?> GetByBrandIdAsync(
        int id,
        int pageSize,
        int pageIndex);

    Task<PaginatedItems<CatalogItem>?> GetByBrandTitleAsync(
        string brand,
        int pageSize,
        int pageIndex);

    Task<CatalogItem?> GetByIdAsync(
        int id);

    Task<PaginatedItems<CatalogItem>?> GetByPageAsync(
        int pageSize,
        int pageIndex,
        int? brandFilter,
        int? typeFilter);

    Task<PaginatedItems<CatalogItem>?> GetByTypeIdAsync(
        int id,
        int pageSize,
        int pageIndex);

    Task<PaginatedItems<CatalogItem>?> GetByTypeTitleAsync(
        string type,
        int pageSize,
        int pageIndex);

    Task<IEnumerable<CatalogItem>?> GetProductsAsync();

    Task<int?> UpdateAsync(
        int id,
        string? name,
        decimal? price,
        int? availableStock,
        int? catalogBrandId,
        int? catalogTypeId,
        string? description,
        string? pictureFileName);
}
