namespace Catalog.Host.Models.Requests;

public class UpdateBrandRequest
{
    public string Brand { get; set; } = null!;

    public int Id { get; set; }
}
