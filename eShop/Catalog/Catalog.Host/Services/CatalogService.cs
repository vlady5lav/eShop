using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogService : BaseDataService<ApplicationDbContext>, ICatalogService
{
    private readonly ICatalogBrandRepository _catalogBrandRepository;
    private readonly ICatalogProductRepository _catalogProductRepository;
    private readonly ICatalogTypeRepository _catalogTypeRepository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public CatalogService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogBrandRepository catalogBrandRepository,
        ICatalogProductRepository catalogProductRepository,
        ICatalogTypeRepository catalogTypeRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogBrandRepository = catalogBrandRepository;
        _catalogProductRepository = catalogProductRepository;
        _catalogTypeRepository = catalogTypeRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<PaginatedItemsResponse<CatalogProductDto>?> GetProductsByPageAsync(int pageSize, int pageIndex)
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogProductRepository.GetByPageAsync(pageIndex, pageSize);

            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogProductDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(cp => _mapper.Map<CatalogProductDto>(cp)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
        });
    }

    public async Task<IEnumerable<CatalogProductDto>?> GetProductsAsync()
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogProductRepository.GetProductsAsync();

            if (result == null)
            {
                return null;
            }

            return _mapper.Map<IEnumerable<CatalogProductDto>?>(result);
        });
    }

    public async Task<PaginatedItemsResponse<CatalogProductDto>?> GetProductsByBrandIdAsync(int id, int pageSize, int pageIndex)
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogProductRepository.GetByBrandIdAsync(id, pageIndex, pageSize);

            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogProductDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(cp => _mapper.Map<CatalogProductDto>(cp)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogProductDto>?> GetProductsByBrandAsync(string brand, int pageSize, int pageIndex)
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogProductRepository.GetByBrandAsync(brand, pageIndex, pageSize);

            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogProductDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(cp => _mapper.Map<CatalogProductDto>(cp)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogProductDto>?> GetProductsByTypeIdAsync(int id, int pageSize, int pageIndex)
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogProductRepository.GetByTypeIdAsync(id, pageIndex, pageSize);

            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogProductDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(cp => _mapper.Map<CatalogProductDto>(cp)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogProductDto>?> GetProductsByTypeAsync(string type, int pageSize, int pageIndex)
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogProductRepository.GetByTypeAsync(type, pageIndex, pageSize);

            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogProductDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(cp => _mapper.Map<CatalogProductDto>(cp)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogBrandDto>?> GetBrandsByPageAsync(int pageSize, int pageIndex)
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogBrandRepository.GetByPageAsync(pageIndex, pageSize);

            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogBrandDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(cp => _mapper.Map<CatalogBrandDto>(cp)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
        });
    }

    public async Task<IEnumerable<CatalogBrandDto>?> GetBrandsAsync()
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogBrandRepository.GetBrandsAsync();

            if (result == null)
            {
                return null;
            }

            return _mapper.Map<IEnumerable<CatalogBrandDto>?>(result);
        });
    }

    public async Task<PaginatedItemsResponse<CatalogTypeDto>?> GetTypesByPageAsync(int pageSize, int pageIndex)
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogTypeRepository.GetByPageAsync(pageIndex, pageSize);

            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogTypeDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(cp => _mapper.Map<CatalogTypeDto>(cp)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
            };
        });
    }

    public async Task<IEnumerable<CatalogTypeDto>?> GetTypesAsync()
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogTypeRepository.GetTypesAsync();

            if (result == null)
            {
                return null;
            }

            return _mapper.Map<IEnumerable<CatalogTypeDto>?>(result);
        });
    }
}
