using Catalog.Host.Configurations;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Responses;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBffController : ControllerBase
{
    private readonly ICatalogService _catalogService;

    private readonly IOptions<CatalogConfig> _config;

    private readonly ILogger<CatalogBffController> _logger;

    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        ICatalogService catalogService,
        IOptions<CatalogConfig> config)
    {
        _logger = logger;
        _catalogService = catalogService;
        _config = config;
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(IEnumerable<CatalogBrandDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetBrands()
    {
        var result = await _catalogService.GetBrandsAsync();

        if (result != null && result.Any())
        {
            return Ok(result);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogBrandDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetBrandsByPage(TPaginatedItemsRequest<bool> request)
    {
        var result = await _catalogService.GetBrandsByPageAsync(
            request.PageSize,
            request.PageIndex);

        if (result != null && result.Data.Any())
        {
            return Ok(result);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetProductById(int id)
    {
        var result = await _catalogService.GetProductByIdAsync(id);

        if (result != null)
        {
            return Ok(result);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(IEnumerable<CatalogItemDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetProducts()
    {
        var result = await _catalogService.GetProductsAsync();

        if (result != null && result.Any())
        {
            return Ok(result);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetProductsByBrandId(TPaginatedItemsRequest<int> request)
    {
        var result = await _catalogService.GetProductsByBrandIdAsync(
            request.Item,
            request.PageSize,
            request.PageIndex);

        if (result != null && result.Data.Any())
        {
            return Ok(result);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetProductsByBrandTitle(TPaginatedItemsRequest<string> request)
    {
        var result = await _catalogService.GetProductsByBrandTitleAsync(
            request.Item ?? string.Empty,
            request.PageSize,
            request.PageIndex);

        if (result != null && result.Data.Any())
        {
            return Ok(result);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetProductsByTypeId(TPaginatedItemsRequest<int> request)
    {
        var result = await _catalogService.GetProductsByTypeIdAsync(
            request.Item,
            request.PageSize,
            request.PageIndex);

        if (result != null && result.Data.Any())
        {
            return Ok(result);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetProductsByTypeTitle(TPaginatedItemsRequest<string> request)
    {
        var result = await _catalogService.GetProductsByTypeTitleAsync(
            request.Item ?? string.Empty,
            request.PageSize,
            request.PageIndex);

        if (result != null && result.Data.Any())
        {
            return Ok(result);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(IEnumerable<CatalogTypeDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetTypes()
    {
        var result = await _catalogService.GetTypesAsync();

        if (result != null && result.Any())
        {
            return Ok(result);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogTypeDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetTypesByPage(TPaginatedItemsRequest<bool> request)
    {
        var result = await _catalogService.GetTypesByPageAsync(request.PageSize, request.PageIndex);

        if (result != null && result.Data.Any())
        {
            return Ok(result);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public IActionResult GetUserId()
    {
        _logger.LogWarning($"User Id {User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value}");
        return Ok();
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Items(PaginatedItemsRequest<CatalogTypeFilter> request)
    {
        var result = await _catalogService.GetCatalogItemsAsync(
            request.PageSize,
            request.PageIndex,
            request.Filters);

        if (result != null && result.Data.Any())
        {
            return Ok(result);
        }
        else
        {
            return NotFound();
        }
    }
}
