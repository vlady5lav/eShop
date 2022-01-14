namespace Catalog.Host.Services.Interfaces;

public interface ICatalogBrandService
{
    Task<int?> CreateBrandAsync(string brand);
    Task<int?> DeleteBrandAsync(int id);
    Task<int?> DeleteBrandByTitleAsync(string brand);
    Task<int?> UpdateBrandAsync(int id, string brand);
}
