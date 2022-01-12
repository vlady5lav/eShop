using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<IEnumerable<CatalogBrandDto>?> GetBrandsAsync();
    Task<IEnumerable<CatalogProductDto>?> GetProductsAsync();
    Task<IEnumerable<CatalogTypeDto>?> GetTypesAsync();
    Task<PaginatedItemsResponse<CatalogBrandDto>?> GetBrandsByPageAsync(int pageSize, int pageIndex);
    Task<PaginatedItemsResponse<CatalogProductDto>?> GetProductsByBrandIdAsync(int id, int pageSize, int pageIndex);
    Task<PaginatedItemsResponse<CatalogProductDto>?> GetProductsByBrandAsync(string brand, int pageSize, int pageIndex);
    Task<PaginatedItemsResponse<CatalogProductDto>?> GetProductsByPageAsync(int pageSize, int pageIndex);
    Task<PaginatedItemsResponse<CatalogProductDto>?> GetProductsByTypeIdAsync(int id, int pageSize, int pageIndex);
    Task<PaginatedItemsResponse<CatalogProductDto>?> GetProductsByTypeAsync(string type, int pageSize, int pageIndex);
    Task<PaginatedItemsResponse<CatalogTypeDto>?> GetTypesByPageAsync(int pageSize, int pageIndex);
}
