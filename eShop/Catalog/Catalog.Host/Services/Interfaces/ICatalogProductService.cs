namespace Catalog.Host.Services.Interfaces;

public interface ICatalogProductService
{
    Task<int?> CreateProductAsync(string name, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string? description, string? pictureFileName);
    Task<int?> DeleteProductAsync(int id);
    Task<int?> UpdateProductAsync(int id, string? name, decimal? price, int? availableStock, int? catalogBrandId, int? catalogTypeId, string? description, string? pictureFileName);
}
