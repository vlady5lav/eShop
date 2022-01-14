using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
{
    private readonly ICatalogBrandRepository _catalogBrandRepository;

    public CatalogBrandService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogBrandRepository catalogBrandRepository)
        : base(dbContextWrapper, logger)
    {
        _catalogBrandRepository = catalogBrandRepository;
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
}
