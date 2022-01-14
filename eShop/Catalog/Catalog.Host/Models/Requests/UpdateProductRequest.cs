namespace Catalog.Host.Models.Requests;

public class UpdateProductRequest
{
    public int Id { get; set; }

    public string? Name { get; set; } = null!;

    public decimal? Price { get; set; }

    public int? AvailableStock { get; set; }

    public string? Description { get; set; } = null!;

    public string? PictureFileName { get; set; } = null!;

    public int? CatalogTypeId { get; set; }

    public int? CatalogBrandId { get; set; }
}
