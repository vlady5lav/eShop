namespace Catalog.Host.Data.Entities;

public class CatalogItem
{
    public int AvailableStock { get; set; }

    public CatalogBrand CatalogBrand { get; set; } = null!;

    public int CatalogBrandId { get; set; }

    public CatalogType CatalogType { get; set; } = null!;

    public int CatalogTypeId { get; set; }

    public string? Description { get; set; }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? PictureFileName { get; set; }

    public decimal Price { get; set; }
}
