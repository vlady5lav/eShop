using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
{
    private readonly ICatalogTypeRepository _catalogTypeRepository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public CatalogTypeService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogTypeRepository catalogTypeRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogTypeRepository = catalogTypeRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<int?> CreateTypeAsync(string type)
    {
        return await ExecuteSafe(async () => await _catalogTypeRepository.AddAsync(type));
    }

    public async Task<int?> DeleteTypeAsync(int id)
    {
        return await ExecuteSafe(async () => await _catalogTypeRepository.RemoveAsync(id));
    }

    public async Task<int?> DeleteTypeByTitleAsync(string type)
    {
        return await ExecuteSafe(async () => await _catalogTypeRepository.RemoveByTitleAsync(type));
    }

    public async Task<int?> UpdateTypeAsync(int id, string type)
    {
        return await ExecuteSafe(async () => await _catalogTypeRepository.UpdateAsync(id, type));
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
                Data = result.Data.Select(ct => _mapper.Map<CatalogTypeDto>(ct)).ToList(),
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

    public async Task<CatalogTypeDto?> GetTypeByIdAsync(int id)
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogTypeRepository.GetByIdAsync(id);

            if (result == null)
            {
                return null;
            }

            return _mapper.Map<CatalogTypeDto>(result);
        });
    }

    public async Task<CatalogTypeDto?> GetByTypeAsync(string type)
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogTypeRepository.GetByTypeAsync(type);

            if (result == null)
            {
                return null;
            }

            return _mapper.Map<CatalogTypeDto>(result);
        });
    }
}
