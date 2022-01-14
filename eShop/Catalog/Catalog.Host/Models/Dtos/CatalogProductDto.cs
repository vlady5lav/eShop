namespace Catalog.Host.Models.Dtos;

public class CatalogProductDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int AvailableStock { get; set; }

    public string? Description { get; set; } = null!;

    public string? PictureUrl { get; set; } = null!;

    public CatalogTypeDto CatalogType { get; set; } = null!;

    public CatalogBrandDto CatalogBrand { get; set; } = null!;
}
