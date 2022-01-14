namespace Catalog.Host.Services.Interfaces;

public interface ICatalogTypeService
{
    Task<int?> CreateTypeAsync(string type);
    Task<int?> DeleteTypeAsync(int id);
    Task<int?> DeleteTypeByTitleAsync(string type);
    Task<int?> UpdateTypeAsync(int id, string type);
}
