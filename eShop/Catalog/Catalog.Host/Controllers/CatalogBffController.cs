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
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetProductsByPageAsync(PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetProductsByPageAsync(request.PageSize, request.PageIndex);

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
    [ProducesResponseType(typeof(IEnumerable<CatalogProductDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetProductsAsync()
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
    [ProducesResponseType(typeof(CatalogProductDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetProductByIdAsync(int id)
    {
        var result = await _catalogProductService.GetProductByIdAsync(id);

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
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogProductDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetProductsByBrandIdAsync(int id, PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetProductsByBrandIdAsync(id, request.PageSize, request.PageIndex);

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
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogProductDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetProductsByBrandAsync(string brand, PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetProductsByBrandAsync(brand, request.PageSize, request.PageIndex);

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
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogProductDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetProductsByTypeIdAsync(int id, PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetProductsByTypeIdAsync(id, request.PageSize, request.PageIndex);

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
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogProductDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetProductsByTypeAsync(string type, PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetProductsByTypeAsync(type, request.PageSize, request.PageIndex);

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
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogBrandDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetBrandsByPage(PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetBrandsByPageAsync(request.PageSize, request.PageIndex);

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
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogTypeDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetTypesByPage(PaginatedItemsRequest request)
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
}
