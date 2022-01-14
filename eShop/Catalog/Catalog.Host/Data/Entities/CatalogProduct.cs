namespace Catalog.Host.Data.Entities;

public class CatalogProduct
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int AvailableStock { get; set; }

    public string? Description { get; set; } = null!;

    public string? PictureFileName { get; set; } = null!;

    public int CatalogTypeId { get; set; }

    public CatalogType CatalogType { get; set; } = null!;

    public int CatalogBrandId { get; set; }

    public CatalogBrand CatalogBrand { get; set; } = null!;
}
