using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Responses;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogService : BaseDataService<ApplicationDbContext>, ICatalogService
{
    private readonly ICatalogBrandRepository _catalogBrandRepository;

    private readonly ICatalogItemRepository _catalogItemRepository;

    private readonly ICatalogTypeRepository _catalogTypeRepository;

    private readonly IMapper _mapper;

    public CatalogService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IMapper mapper,
        ICatalogBrandRepository catalogBrandRepository,
        ICatalogItemRepository catalogItemRepository,
        ICatalogTypeRepository catalogTypeRepository)
        : base(dbContextWrapper, logger)
    {
        _catalogBrandRepository = catalogBrandRepository;
        _catalogItemRepository = catalogItemRepository;
        _catalogTypeRepository = catalogTypeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CatalogBrandDto>?> GetBrandsAsync()
    {
        return await ExecuteSafeAsync(
            async () =>
            {
                var result = await _catalogBrandRepository.GetBrandsAsync();

                if (result == null)
                {
                    return null;
                }

                return _mapper.Map<IEnumerable<CatalogBrandDto>?>(result);
            });
    }

    public async Task<PaginatedItemsResponse<CatalogBrandDto>?> GetBrandsByPageAsync(
        int pageSize,
        int pageIndex)
    {
        return await ExecuteSafeAsync(
            async () =>
            {
                var result = await _catalogBrandRepository.GetByPageAsync(pageSize, pageIndex);

                if (result == null)
                {
                    return null;
                }

                return new PaginatedItemsResponse<CatalogBrandDto>()
                {
                    Count = result.TotalCount,
                    Data = result.Data.Select(cb => _mapper.Map<CatalogBrandDto>(cb)).ToList(),
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                };
            });
    }

    public async Task<PaginatedItemsResponse<CatalogItemDto>?> GetCatalogItemsAsync(
        int pageSize,
        int pageIndex,
        Dictionary<CatalogTypeFilter, int>? filters = null)
    {
        return await ExecuteSafeAsync(async () =>
        {
            int? brandFilter = null;
            int? typeFilter = null;

            if (filters != null)
            {
                if (filters.TryGetValue(CatalogTypeFilter.Brand, out var brand))
                {
                    brandFilter = brand;
                }

                if (filters.TryGetValue(CatalogTypeFilter.Type, out var type))
                {
                    typeFilter = type;
                }
            }

            var result = await _catalogItemRepository.GetByPageAsync(
                pageSize,
                pageIndex,
                brandFilter,
                typeFilter);

            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogItemDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(ci => _mapper.Map<CatalogItemDto>(ci)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
        });
    }

    public async Task<CatalogItemDto?> GetProductByIdAsync(int id)
    {
        return await ExecuteSafeAsync(
            async () =>
            {
                var result = await _catalogItemRepository.GetByIdAsync(id);

                if (result == null)
                {
                    return null;
                }

                return _mapper.Map<CatalogItemDto>(result);
            });
    }

    public async Task<IEnumerable<CatalogItemDto>?> GetProductsAsync()
    {
        return await ExecuteSafeAsync(
            async () =>
            {
                var result = await _catalogItemRepository.GetProductsAsync();

                if (result == null)
                {
                    return null;
                }

                return _mapper.Map<IEnumerable<CatalogItemDto>?>(result);
            });
    }

    public async Task<PaginatedItemsResponse<CatalogItemDto>?> GetProductsByBrandIdAsync(
        int id,
        int pageSize,
        int pageIndex)
    {
        return await ExecuteSafeAsync(
            async () =>
            {
                var result = await _catalogItemRepository.GetByBrandIdAsync(
                    id,
                    pageSize,
                    pageIndex);

                if (result == null)
                {
                    return null;
                }

                return new PaginatedItemsResponse<CatalogItemDto>()
                {
                    Count = result.TotalCount,
                    Data = result.Data.Select(ci => _mapper.Map<CatalogItemDto>(ci)).ToList(),
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                };
            });
    }

    public async Task<PaginatedItemsResponse<CatalogItemDto>?> GetProductsByBrandTitleAsync(
        string brand,
        int pageSize,
        int pageIndex)
    {
        return await ExecuteSafeAsync(
            async () =>
            {
                var result = await _catalogItemRepository.GetByBrandTitleAsync(
                    brand,
                    pageSize,
                    pageIndex);

                if (result == null)
                {
                    return null;
                }

                return new PaginatedItemsResponse<CatalogItemDto>()
                {
                    Count = result.TotalCount,
                    Data = result.Data.Select(ci => _mapper.Map<CatalogItemDto>(ci)).ToList(),
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                };
            });
    }

    public async Task<PaginatedItemsResponse<CatalogItemDto>?> GetProductsByTypeIdAsync(
        int id,
        int pageSize,
        int pageIndex)
    {
        return await ExecuteSafeAsync(
            async () =>
            {
                var result = await _catalogItemRepository.GetByTypeIdAsync(
                    id,
                    pageSize,
                    pageIndex);

                if (result == null)
                {
                    return null;
                }

                return new PaginatedItemsResponse<CatalogItemDto>()
                {
                    Count = result.TotalCount,
                    Data = result.Data.Select(ci => _mapper.Map<CatalogItemDto>(ci)).ToList(),
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                };
            });
    }

    public async Task<PaginatedItemsResponse<CatalogItemDto>?> GetProductsByTypeTitleAsync(
        string type,
        int pageSize,
        int pageIndex)
    {
        return await ExecuteSafeAsync(
            async () =>
            {
                var result = await _catalogItemRepository.GetByTypeTitleAsync(
                    type,
                    pageSize,
                    pageIndex);

                if (result == null)
                {
                    return null;
                }

                return new PaginatedItemsResponse<CatalogItemDto>()
                {
                    Count = result.TotalCount,
                    Data = result.Data.Select(ci => _mapper.Map<CatalogItemDto>(ci)).ToList(),
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                };
            });
    }

    public async Task<IEnumerable<CatalogTypeDto>?> GetTypesAsync()
    {
        return await ExecuteSafeAsync(
            async () =>
            {
                var result = await _catalogTypeRepository.GetTypesAsync();

                if (result == null)
                {
                    return null;
                }

                return _mapper.Map<IEnumerable<CatalogTypeDto>?>(result);
            });
    }

    public async Task<PaginatedItemsResponse<CatalogTypeDto>?> GetTypesByPageAsync(
        int pageSize,
        int pageIndex)
    {
        return await ExecuteSafeAsync(
            async () =>
            {
                var result = await _catalogTypeRepository.GetByPageAsync(pageSize, pageIndex);

                if (result == null)
                {
                    return null;
                }

                return new PaginatedItemsResponse<CatalogTypeDto>()
                {
                    Count = result.TotalCount,
                    Data = result.Data.Select(ct => _mapper.Map<CatalogTypeDto>(ct)).ToList(),
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                };
            });
    }
}
