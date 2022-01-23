namespace Catalog.Host.Models.Dtos;

public class CatalogItemDto
{
    public int AvailableStock { get; set; }

    public CatalogBrandDto CatalogBrand { get; set; } = null!;

    public CatalogTypeDto CatalogType { get; set; } = null!;

    public string? Description { get; set; }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? PictureUrl { get; set; }

    public decimal Price { get; set; }
}
