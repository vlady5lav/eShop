namespace Catalog.Host.Models.Requests;

public class CreateProductRequest
{
    public int AvailableStock { get; set; }

    public int CatalogBrandId { get; set; }

    public int CatalogTypeId { get; set; }

    public string? Description { get; set; }

    public string Name { get; set; } = null!;

    public string? PictureFileName { get; set; }

    public decimal Price { get; set; }
}
