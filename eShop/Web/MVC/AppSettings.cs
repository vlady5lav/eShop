namespace MVC;

public class AppSettings
{
    public string CallBackUrl { get; set; } = null!;

    public string CatalogUrl { get; set; } = null!;

    public string IdentityUrl { get; set; } = null!;

    public int SessionCookieLifetimeMinutes { get; set; }
}
