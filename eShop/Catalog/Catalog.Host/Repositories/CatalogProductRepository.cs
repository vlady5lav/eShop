using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public class CatalogProductRepository : ICatalogProductRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogProductRepository> _logger;

    public CatalogProductRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogProductRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<PaginatedItems<CatalogProduct>?> GetByPageAsync(int pageIndex, int pageSize)
    {
        var totalItems = await _dbContext.CatalogProducts
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogProducts
            .Include(ci => ci.CatalogBrand)
            .Include(ci => ci.CatalogType)
            .OrderBy(ci => ci.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogProduct>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<IEnumerable<CatalogProduct>?> GetProductsAsync()
    {
        var items = await _dbContext.CatalogProducts
            .Include(ci => ci.CatalogBrand)
            .Include(ci => ci.CatalogType)
            .OrderBy(cb => cb.Name)
            .ToListAsync();

        return items;
    }

    public async Task<CatalogProduct?> GetByIdAsync(int id)
    {
        var result = await _dbContext.CatalogProducts
            .Include(ci => ci.CatalogBrand)
            .Include(ci => ci.CatalogType)
            .SingleOrDefaultAsync(ci => ci.Id == id);

        return result;
    }

    public async Task<PaginatedItems<CatalogProduct>?> GetByBrandIdAsync(int id, int pageIndex, int pageSize)
    {
        var totalItems = await _dbContext.CatalogProducts
            .Include(ci => ci.CatalogBrand)
            .Where(ci => ci.CatalogBrand.Id == id)
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogProducts
            .Include(ci => ci.CatalogBrand)
            .Where(ci => ci.CatalogBrand.Id == id)
            .Include(ci => ci.CatalogType)
            .OrderBy(ci => ci.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogProduct>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<PaginatedItems<CatalogProduct>?> GetByBrandAsync(string brand, int pageIndex, int pageSize)
    {
        var totalItems = await _dbContext.CatalogProducts
            .Include(ci => ci.CatalogBrand)
            .Where(ci => ci.CatalogBrand.Brand == brand)
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogProducts
            .Include(ci => ci.CatalogBrand)
            .Where(ci => ci.CatalogBrand.Brand == brand)
            .Include(ci => ci.CatalogType)
            .OrderBy(ci => ci.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogProduct>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<PaginatedItems<CatalogProduct>?> GetByTypeIdAsync(int id, int pageIndex, int pageSize)
    {
        var totalItems = await _dbContext.CatalogProducts
            .Include(ci => ci.CatalogType)
            .Where(ci => ci.CatalogType.Id == id)
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogProducts
            .Include(ci => ci.CatalogType)
            .Where(ci => ci.CatalogType.Id == id)
            .Include(ci => ci.CatalogBrand)
            .OrderBy(ci => ci.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogProduct>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<PaginatedItems<CatalogProduct>?> GetByTypeAsync(string type, int pageIndex, int pageSize)
    {
        var totalItems = await _dbContext.CatalogProducts
            .Include(ci => ci.CatalogType)
            .Where(ci => ci.CatalogType.Type == type)
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogProducts
            .Include(ci => ci.CatalogType)
            .Where(ci => ci.CatalogType.Type == type)
            .Include(ci => ci.CatalogBrand)
            .OrderBy(ci => ci.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogProduct>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<int?> AddAsync(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        var item = await _dbContext.CatalogProducts.AddAsync(new CatalogProduct
        {
            Name = name,
            Description = description,
            Price = price,
            AvailableStock = availableStock,
            CatalogBrandId = catalogBrandId,
            CatalogTypeId = catalogTypeId,
            PictureFileName = pictureFileName,
        });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<int?> RemoveAsync(int id)
    {
        var item = await _dbContext.CatalogProducts.SingleOrDefaultAsync(ci => ci.Id == id) ?? throw new NullReferenceException();

        _dbContext.CatalogProducts.Remove(item);

        await _dbContext.SaveChangesAsync();

        return item.Id;
    }

    public async Task<int?> UpdateAsync(int id, string? name, string? description, decimal? price, int? availableStock, int? catalogBrandId, int? catalogTypeId, string? pictureFileName)
    {
        var item = await _dbContext.CatalogProducts.SingleOrDefaultAsync(ci => ci.Id == id) ?? throw new NullReferenceException();

        item.Name = name ?? item.Name;
        item.Description = description ?? item.Description;
        item.Price = price ?? item.Price;
        item.AvailableStock = availableStock ?? item.AvailableStock;
        item.CatalogBrandId = catalogBrandId ?? item.CatalogBrandId;
        item.CatalogTypeId = catalogTypeId ?? item.CatalogTypeId;
        item.PictureFileName = pictureFileName ?? item.PictureFileName;

        _dbContext.CatalogProducts.Update(item);

        await _dbContext.SaveChangesAsync();

        return item.Id;
    }
}
