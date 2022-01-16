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

    public async Task<PaginatedItems<CatalogProduct>?> GetByPageAsync(int pageSize, int pageIndex)
    {
        var totalItems = await _dbContext.CatalogProducts
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogProducts
            .Include(cp => cp.CatalogBrand)
            .Include(cp => cp.CatalogType)
            .OrderBy(cp => cp.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogProduct>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<IEnumerable<CatalogProduct>?> GetProductsAsync()
    {
        var result = await _dbContext.CatalogProducts
            .Include(cp => cp.CatalogBrand)
            .Include(cp => cp.CatalogType)
            .OrderBy(cb => cb.Name)
            .ToListAsync();

        return result;
    }

    public async Task<CatalogProduct?> GetByIdAsync(int id)
    {
        var result = await _dbContext.CatalogProducts
            .Include(cp => cp.CatalogBrand)
            .Include(cp => cp.CatalogType)
            .FirstOrDefaultAsync(cp => cp.Id == id);

        return result;
    }

    public async Task<PaginatedItems<CatalogProduct>?> GetByBrandIdAsync(int id, int pageSize, int pageIndex)
    {
        var totalItems = await _dbContext.CatalogProducts
            .Include(cp => cp.CatalogBrand)
            .Where(cp => cp.CatalogBrand.Id == id)
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogProducts
            .Include(cp => cp.CatalogBrand)
            .Where(cp => cp.CatalogBrand.Id == id)
            .Include(cp => cp.CatalogType)
            .OrderBy(cp => cp.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogProduct>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<PaginatedItems<CatalogProduct>?> GetByBrandTitleAsync(string brand, int pageSize, int pageIndex)
    {
        var totalItems = await _dbContext.CatalogProducts
            .Include(cp => cp.CatalogBrand)
            .Where(cp => cp.CatalogBrand.Brand == brand)
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogProducts
            .Include(cp => cp.CatalogBrand)
            .Where(cp => cp.CatalogBrand.Brand == brand)
            .Include(cp => cp.CatalogType)
            .OrderBy(cp => cp.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogProduct>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<PaginatedItems<CatalogProduct>?> GetByTypeIdAsync(int id, int pageSize, int pageIndex)
    {
        var totalItems = await _dbContext.CatalogProducts
            .Include(cp => cp.CatalogType)
            .Where(cp => cp.CatalogType.Id == id)
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogProducts
            .Include(cp => cp.CatalogType)
            .Where(cp => cp.CatalogType.Id == id)
            .Include(cp => cp.CatalogBrand)
            .OrderBy(cp => cp.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogProduct>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<PaginatedItems<CatalogProduct>?> GetByTypeTitleAsync(string type, int pageSize, int pageIndex)
    {
        var totalItems = await _dbContext.CatalogProducts
            .Include(cp => cp.CatalogType)
            .Where(cp => cp.CatalogType.Type == type)
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogProducts
            .Include(cp => cp.CatalogType)
            .Where(cp => cp.CatalogType.Type == type)
            .Include(cp => cp.CatalogBrand)
            .OrderBy(cp => cp.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogProduct>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<int?> AddAsync(string name, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string? description, string? pictureFileName)
    {
        var addItem = new CatalogProduct
        {
            Name = name,
            Price = price,
            AvailableStock = availableStock,
            CatalogBrandId = catalogBrandId,
            CatalogTypeId = catalogTypeId,
            Description = description ?? null,
            PictureFileName = pictureFileName ?? null,
        };

        var item = await _dbContext.CatalogProducts.AddAsync(addItem);

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<int?> DeleteAsync(int id)
    {
        var item = await _dbContext.CatalogProducts.FirstOrDefaultAsync(cp => cp.Id == id);

        if (item != null)
        {
            _dbContext.CatalogProducts.Remove(item);

            await _dbContext.SaveChangesAsync();

            return item.Id;
        }
        else
        {
            return null;
        }
    }

    public async Task<int?> UpdateAsync(int id, string? name, decimal? price, int? availableStock, int? catalogBrandId, int? catalogTypeId, string? description, string? pictureFileName)
    {
        var item = await _dbContext.CatalogProducts.FirstOrDefaultAsync(cp => cp.Id == id);

        if (item != null)
        {
            item.Name = name ?? item.Name;
            item.Price = price ?? item.Price;
            item.AvailableStock = availableStock ?? item.AvailableStock;
            item.CatalogBrandId = catalogBrandId ?? item.CatalogBrandId;
            item.CatalogTypeId = catalogTypeId ?? item.CatalogTypeId;
            item.Description = description ?? item.Description;
            item.PictureFileName = pictureFileName ?? item.PictureFileName;

            _dbContext.CatalogProducts.Update(item);

            await _dbContext.SaveChangesAsync();

            return item.Id;
        }
        else
        {
            return null;
        }
    }
}
