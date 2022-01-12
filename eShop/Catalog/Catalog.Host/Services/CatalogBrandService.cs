using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
{
    private readonly ICatalogBrandRepository _catalogBrandRepository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public CatalogBrandService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogBrandRepository catalogBrandRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogBrandRepository = catalogBrandRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<int?> CreateBrandAsync(string brand)
    {
        return await ExecuteSafe(async () => await _catalogBrandRepository.AddAsync(brand));
    }

    public async Task<int?> DeleteBrandAsync(int id)
    {
        return await ExecuteSafe(async () => await _catalogBrandRepository.RemoveAsync(id));
    }

    public async Task<int?> DeleteBrandByTitleAsync(string brand)
    {
        return await ExecuteSafe(async () => await _catalogBrandRepository.RemoveByTitleAsync(brand));
    }

    public async Task<int?> UpdateBrandAsync(int id, string brand)
    {
        return await ExecuteSafe(async () => await _catalogBrandRepository.UpdateAsync(id, brand));
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
                Data = result.Data.Select(cb => _mapper.Map<CatalogBrandDto>(cb)).ToList(),
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

    public async Task<CatalogBrandDto?> GetBrandByIdAsync(int id)
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogBrandRepository.GetByIdAsync(id);

            if (result == null)
            {
                return null;
            }

            return _mapper.Map<CatalogBrandDto>(result);
        });
    }

    public async Task<CatalogBrandDto?> GetByBrandAsync(string brand)
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogBrandRepository.GetByBrandAsync(brand);

            if (result == null)
            {
                return null;
            }

            return _mapper.Map<CatalogBrandDto>(result);
        });
    }
}
