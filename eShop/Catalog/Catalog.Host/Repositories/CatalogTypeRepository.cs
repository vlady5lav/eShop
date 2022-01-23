using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public class CatalogTypeRepository : ICatalogTypeRepository
{
    private readonly ApplicationDbContext _dbContext;

    private readonly ILogger<CatalogItemRepository> _logger;

    public CatalogTypeRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogItemRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int?> AddAsync(string type)
    {
        var addItem = new CatalogType { Type = type, };

        var item = await _dbContext.CatalogTypes.AddAsync(addItem);

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<int?> DeleteAsync(int id)
    {
        var item = await _dbContext.CatalogTypes.FirstOrDefaultAsync(ct => ct.Id == id);

        if (item != null)
        {
            _dbContext.CatalogTypes.Remove(item);

            await _dbContext.SaveChangesAsync();

            return item.Id;
        }
        else
        {
            return null;
        }
    }

    public async Task<int?> DeleteByTitleAsync(string type)
    {
        var item = await _dbContext.CatalogTypes.FirstOrDefaultAsync(ct => ct.Type == type);

        if (item != null)
        {
            _dbContext.CatalogTypes.Remove(item);

            await _dbContext.SaveChangesAsync();

            return item.Id;
        }
        else
        {
            return null;
        }
    }

    public async Task<PaginatedItems<CatalogType>?> GetByPageAsync(int pageSize, int pageIndex)
    {
        var totalItems = await _dbContext.CatalogTypes.LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogTypes
            .OrderBy(ct => ct.Type)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogType>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<CatalogType?> GetByTypeIdAsync(int id)
    {
        var result = await _dbContext.CatalogTypes.FirstOrDefaultAsync(ct => ct.Id == id);

        return result;
    }

    public async Task<CatalogType?> GetByTypeTitleAsync(string type)
    {
        var result = await _dbContext.CatalogTypes.FirstOrDefaultAsync(ct => ct.Type == type);

        return result;
    }

    public async Task<IEnumerable<CatalogType>?> GetTypesAsync()
    {
        var result = await _dbContext.CatalogTypes.OrderBy(ct => ct.Type).ToListAsync();

        return result;
    }

    public async Task<int?> UpdateAsync(int id, string type)
    {
        var item = await _dbContext.CatalogTypes.FirstOrDefaultAsync(ct => ct.Id == id);

        if (item != null)
        {
            item.Type = type;

            _dbContext.CatalogTypes.Update(item);

            await _dbContext.SaveChangesAsync();

            return item.Id;
        }
        else
        {
            return null;
        }
    }
}
