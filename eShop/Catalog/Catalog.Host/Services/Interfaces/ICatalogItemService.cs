namespace Catalog.Host.Services.Interfaces;

public interface ICatalogItemService
{
    Task<int?> AddAsync(
        string name,
        decimal price,
        int availableStock,
        int catalogBrandId,
        int catalogTypeId,
        string? description,
        string? pictureFileName);

    Task<int?> DeleteAsync(int id);

    Task<int?> UpdateAsync(
        int id,
        string? name,
        decimal? price,
        int? availableStock,
        int? catalogBrandId,
        int? catalogTypeId,
        string? description,
        string? pictureFileName);
}
