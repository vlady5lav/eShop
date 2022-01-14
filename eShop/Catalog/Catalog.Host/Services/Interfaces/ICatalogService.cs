using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Responses;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<CatalogProductDto?> GetProductByIdAsync(int id);
    Task<IEnumerable<CatalogBrandDto>?> GetBrandsAsync();
    Task<IEnumerable<CatalogProductDto>?> GetProductsAsync();
    Task<IEnumerable<CatalogTypeDto>?> GetTypesAsync();
    Task<PaginatedItemsResponse<CatalogBrandDto>?> GetBrandsByPageAsync(int pageSize, int pageIndex);
    Task<PaginatedItemsResponse<CatalogProductDto>?> GetProductsByBrandTitleAsync(string brand, int pageSize, int pageIndex);
    Task<PaginatedItemsResponse<CatalogProductDto>?> GetProductsByBrandIdAsync(int id, int pageSize, int pageIndex);
    Task<PaginatedItemsResponse<CatalogProductDto>?> GetProductsByPageAsync(int pageSize, int pageIndex);
    Task<PaginatedItemsResponse<CatalogProductDto>?> GetProductsByTypeTitleAsync(string type, int pageSize, int pageIndex);
    Task<PaginatedItemsResponse<CatalogProductDto>?> GetProductsByTypeIdAsync(int id, int pageSize, int pageIndex);
    Task<PaginatedItemsResponse<CatalogTypeDto>?> GetTypesByPageAsync(int pageSize, int pageIndex);
}
