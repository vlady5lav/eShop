using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogProductService : BaseDataService<ApplicationDbContext>, ICatalogProductService
{
    private readonly ICatalogProductRepository _catalogProductRepository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public CatalogProductService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogProductRepository catalogProductRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogProductRepository = catalogProductRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<int?> CreateProductAsync(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        return await ExecuteSafe(async () => await _catalogProductRepository.AddAsync(name, description, price, availableStock, catalogBrandId, catalogTypeId, pictureFileName));
    }

    public async Task<int?> DeleteProductAsync(int id)
    {
        return await ExecuteSafe(async () => await _catalogProductRepository.RemoveAsync(id));
    }

    public async Task<int?> UpdateProductAsync(int id, string? name, string? description, decimal? price, int? availableStock, int? catalogBrandId, int? catalogTypeId, string? pictureFileName)
    {
        return await ExecuteSafe(async () => await _catalogProductRepository.UpdateAsync(id, name, description, price, availableStock, catalogBrandId, catalogTypeId, pictureFileName));
    }

    public async Task<CatalogProductDto?> GetProductByIdAsync(int id)
    {
        return await ExecuteSafe(async () =>
        {
            var result = await _catalogProductRepository.GetByIdAsync(id);

            if (result == null)
            {
                return null;
            }

            return _mapper.Map<CatalogProductDto>(result);
        });
    }
}
