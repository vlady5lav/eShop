using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public class CatalogItemRepository : ICatalogItemRepository
{
    private readonly ApplicationDbContext _dbContext;

    private readonly ILogger<CatalogItemRepository> _logger;

    public CatalogItemRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogItemRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int?> AddAsync(
        string name,
        decimal price,
        int availableStock,
        int catalogBrandId,
        int catalogTypeId,
        string? description,
        string? pictureFileName)
    {
        var addItem = new CatalogItem
        {
            Name = name,
            Price = price,
            AvailableStock = availableStock,
            CatalogBrandId = catalogBrandId,
            CatalogTypeId = catalogTypeId,
            Description = description ?? null,
            PictureFileName = pictureFileName ?? null,
        };

        var item = await _dbContext.CatalogItems.AddAsync(addItem);

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<int?> DeleteAsync(int id)
    {
        var item = await _dbContext.CatalogItems.FirstOrDefaultAsync(ci => ci.Id == id);

        if (item != null)
        {
            _dbContext.CatalogItems.Remove(item);

            await _dbContext.SaveChangesAsync();

            return item.Id;
        }
        else
        {
            return null;
        }
    }

    public async Task<PaginatedItems<CatalogItem>?> GetByBrandIdAsync(
        int id,
        int pageSize,
        int pageIndex)
    {
        var totalItems = await _dbContext.CatalogItems
            .Include(ci => ci.CatalogBrand)
            .Where(ci => ci.CatalogBrand.Id == id)
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogItems
            .Include(ci => ci.CatalogBrand)
            .Where(ci => ci.CatalogBrand.Id == id)
            .Include(ci => ci.CatalogType)
            .OrderBy(ci => ci.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<PaginatedItems<CatalogItem>?> GetByBrandTitleAsync(
        string brand,
        int pageSize,
        int pageIndex)
    {
        var totalItems = await _dbContext.CatalogItems
            .Include(ci => ci.CatalogBrand)
            .Where(ci => ci.CatalogBrand.Brand == brand)
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogItems
            .Include(ci => ci.CatalogBrand)
            .Where(ci => ci.CatalogBrand.Brand == brand)
            .Include(ci => ci.CatalogType)
            .OrderBy(ci => ci.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<CatalogItem?> GetByIdAsync(int id)
    {
        var result = await _dbContext.CatalogItems
            .Include(ci => ci.CatalogBrand)
            .Include(ci => ci.CatalogType)
            .FirstOrDefaultAsync(ci => ci.Id == id);

        return result;
    }

    public async Task<PaginatedItems<CatalogItem>?> GetByPageAsync(
        int pageSize,
        int pageIndex,
        int? brandFilter,
        int? typeFilter)
    {
        IQueryable<CatalogItem> query = _dbContext.CatalogItems;

        if (brandFilter.HasValue)
        {
            query = query.Where(w => w.CatalogBrandId == brandFilter.Value);
        }

        if (typeFilter.HasValue)
        {
            query = query.Where(w => w.CatalogTypeId == typeFilter.Value);
        }

        var totalItems = await query.LongCountAsync();

        var itemsOnPage = await query
            .OrderBy(ci => ci.Name)
            .Include(ci => ci.CatalogBrand)
            .Include(ci => ci.CatalogType)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<PaginatedItems<CatalogItem>?> GetByTypeIdAsync(
        int id,
        int pageSize,
        int pageIndex)
    {
        var totalItems = await _dbContext.CatalogItems
            .Include(ci => ci.CatalogType)
            .Where(ci => ci.CatalogType.Id == id)
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogItems
            .Include(ci => ci.CatalogType)
            .Where(ci => ci.CatalogType.Id == id)
            .Include(ci => ci.CatalogBrand)
            .OrderBy(ci => ci.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<PaginatedItems<CatalogItem>?> GetByTypeTitleAsync(
        string type,
        int pageSize,
        int pageIndex)
    {
        var totalItems = await _dbContext.CatalogItems
            .Include(ci => ci.CatalogType)
            .Where(ci => ci.CatalogType.Type == type)
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogItems
            .Include(ci => ci.CatalogType)
            .Where(ci => ci.CatalogType.Type == type)
            .Include(ci => ci.CatalogBrand)
            .OrderBy(ci => ci.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<IEnumerable<CatalogItem>?> GetProductsAsync()
    {
        var result = await _dbContext.CatalogItems
            .Include(ci => ci.CatalogBrand)
            .Include(ci => ci.CatalogType)
            .OrderBy(cb => cb.Name)
            .ToListAsync();

        return result;
    }

    public async Task<int?> UpdateAsync(
        int id,
        string? name,
        decimal? price,
        int? availableStock,
        int? catalogBrandId,
        int? catalogTypeId,
        string? description,
        string? pictureFileName)
    {
        var item = await _dbContext.CatalogItems.FirstOrDefaultAsync(ci => ci.Id == id);

        if (item != null)
        {
            item.Name = name ?? item.Name;
            item.Price = price ?? item.Price;
            item.AvailableStock = availableStock ?? item.AvailableStock;
            item.CatalogBrandId = catalogBrandId ?? item.CatalogBrandId;
            item.CatalogTypeId = catalogTypeId ?? item.CatalogTypeId;
            item.Description = description ?? item.Description;
            item.PictureFileName = pictureFileName ?? item.PictureFileName;

            _dbContext.CatalogItems.Update(item);

            await _dbContext.SaveChangesAsync();

            return item.Id;
        }
        else
        {
            return null;
        }
    }
}
