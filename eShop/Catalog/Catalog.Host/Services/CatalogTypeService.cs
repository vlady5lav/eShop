using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
{
    private readonly ICatalogTypeRepository _catalogTypeRepository;

    public CatalogTypeService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogTypeRepository catalogTypeRepository)
        : base(dbContextWrapper, logger)
    {
        _catalogTypeRepository = catalogTypeRepository;
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
}
