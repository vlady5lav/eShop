using MVC.Models.Enums;
using MVC.Models.Requests;
using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Services;

public class CatalogService : ICatalogService
{
    private readonly IHttpClientService _httpClient;

    private readonly ILogger<CatalogService> _logger;

    private readonly IOptions<AppSettings> _settings;

    public CatalogService(IHttpClientService httpClient, ILogger<CatalogService> logger, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;
        _logger = logger;
    }

    public async Task<IEnumerable<SelectListItem>> GetBrandsAsync()
    {
        var list = new List<SelectListItem> { new SelectListItem() { Text = "All" }, };

        var result = await _httpClient.SendAsync<IEnumerable<CatalogBrand>, string?>(
            $"{_settings.Value.CatalogUrl}/GetBrands",
            HttpMethod.Post,
            null);

        foreach (var catalogBrand in result)
        {
            list.Add(
                new SelectListItem()
                {
                    Text = catalogBrand.Brand,
                    Value = catalogBrand.Id.ToString(),
                });
        }

        return list;
    }

    public async Task<Catalog> GetCatalogItemsAsync(int page, int take, int? brand, int? type)
    {
        var filters = new Dictionary<CatalogTypeFilter, int>();

        if (brand.HasValue)
        {
            filters.Add(CatalogTypeFilter.Brand, brand.Value);
        }

        if (type.HasValue)
        {
            filters.Add(CatalogTypeFilter.Type, type.Value);
        }

        var result = await _httpClient.SendAsync<Catalog, PaginatedItemsRequest<CatalogTypeFilter>>(
            $"{_settings.Value.CatalogUrl}/Items",
            HttpMethod.Post,
            new PaginatedItemsRequest<CatalogTypeFilter>()
            {
                PageIndex = page,
                PageSize = take,
                Filters = filters,
            });

        return result ?? new Catalog() { Count = 0, Data = new List<CatalogItem>(), PageSize = 0, PageIndex = 0 };
    }

    public async Task<IEnumerable<SelectListItem>> GetTypesAsync()
    {
        var list = new List<SelectListItem> { new SelectListItem() { Text = "All" }, };

        var result = await _httpClient.SendAsync<IEnumerable<CatalogType>, string?>(
            $"{_settings.Value.CatalogUrl}/GetTypes",
            HttpMethod.Post,
            null);

        foreach (var catalogType in result)
        {
            list.Add(
                new SelectListItem() { Text = catalogType.Type, Value = catalogType.Id.ToString(), });
        }

        return list;
    }
}
