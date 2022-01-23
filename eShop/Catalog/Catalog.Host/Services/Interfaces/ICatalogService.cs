using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Responses;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<IEnumerable<CatalogBrandDto>?> GetBrandsAsync();

    Task<PaginatedItemsResponse<CatalogBrandDto>?> GetBrandsByPageAsync(
        int pageSize,
        int pageIndex);

    Task<PaginatedItemsResponse<CatalogItemDto>?> GetCatalogItemsAsync(
        int pageSize,
        int pageIndex,
        Dictionary<CatalogTypeFilter, int>? filters = null);

    Task<CatalogItemDto?> GetProductByIdAsync(int id);

    Task<IEnumerable<CatalogItemDto>?> GetProductsAsync();

    Task<PaginatedItemsResponse<CatalogItemDto>?> GetProductsByBrandIdAsync(
        int id,
        int pageSize,
        int pageIndex);

    Task<PaginatedItemsResponse<CatalogItemDto>?> GetProductsByBrandTitleAsync(
        string brand,
        int pageSize,
        int pageIndex);

    Task<PaginatedItemsResponse<CatalogItemDto>?> GetProductsByTypeIdAsync(
        int id,
        int pageSize,
        int pageIndex);

    Task<PaginatedItemsResponse<CatalogItemDto>?> GetProductsByTypeTitleAsync(
        string type,
        int pageSize,
        int pageIndex);

    Task<IEnumerable<CatalogTypeDto>?> GetTypesAsync();

    Task<PaginatedItemsResponse<CatalogTypeDto>?> GetTypesByPageAsync(
        int pageSize,
        int pageIndex);
}
