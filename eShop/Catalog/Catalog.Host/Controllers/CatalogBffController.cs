using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBffController : ControllerBase
{
    private readonly ILogger<CatalogBffController> _logger;
    private readonly ICatalogService _catalogService;
    private readonly ICatalogProductService _catalogProductService;

    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        ICatalogService catalogService,
        ICatalogProductService catalogProductService)
    {
        _logger = logger;
        _catalogService = catalogService;
        _catalogProductService = catalogProductService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductsByPageAsync(PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetProductsByPageAsync(request.PageSize, request.PageIndex);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<CatalogProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductsAsync()
    {
        var result = await _catalogService.GetProductsAsync();

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CatalogProductDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductByIdAsync(int id)
    {
        var result = await _catalogProductService.GetProductByIdAsync(id);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductsByBrandIdAsync(int id, PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetProductsByBrandIdAsync(id, request.PageSize, request.PageIndex);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductsByBrandAsync(string brand, PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetProductsByBrandAsync(brand, request.PageSize, request.PageIndex);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductsByTypeIdAsync(int id, PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetProductsByTypeIdAsync(id, request.PageSize, request.PageIndex);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogProductDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductsByTypeAsync(string type, PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetProductsByTypeAsync(type, request.PageSize, request.PageIndex);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogBrandDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBrandsByPage(PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetBrandsByPageAsync(request.PageSize, request.PageIndex);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<CatalogBrandDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBrands()
    {
        var result = await _catalogService.GetBrandsAsync();

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogTypeDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetTypesByPage(PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetTypesByPageAsync(request.PageSize, request.PageIndex);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<CatalogTypeDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetTypes()
    {
        var result = await _catalogService.GetTypesAsync();

        return Ok(result);
    }
}
