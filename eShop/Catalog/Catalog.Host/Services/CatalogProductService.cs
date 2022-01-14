using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogProductService : BaseDataService<ApplicationDbContext>, ICatalogProductService
{
    private readonly ICatalogProductRepository _catalogProductRepository;

    public CatalogProductService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogProductRepository catalogProductRepository)
        : base(dbContextWrapper, logger)
    {
        _catalogProductRepository = catalogProductRepository;
    }

    public async Task<int?> CreateProductAsync(string name, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string? description, string? pictureFileName)
    {
        return await ExecuteSafe(async () => await _catalogProductRepository.AddAsync(name, price, availableStock, catalogBrandId, catalogTypeId, description, pictureFileName));
    }

    public async Task<int?> DeleteProductAsync(int id)
    {
        return await ExecuteSafe(async () => await _catalogProductRepository.RemoveAsync(id));
    }

    public async Task<int?> UpdateProductAsync(int id, string? name, decimal? price, int? availableStock, int? catalogBrandId, int? catalogTypeId, string? description, string? pictureFileName)
    {
        return await ExecuteSafe(async () => await _catalogProductRepository.UpdateAsync(id, name, price, availableStock, catalogBrandId, catalogTypeId, description, pictureFileName));
    }
}
