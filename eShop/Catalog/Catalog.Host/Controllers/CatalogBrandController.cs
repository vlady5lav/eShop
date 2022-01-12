using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBrandController : ControllerBase
{
    private readonly ILogger<CatalogBrandController> _logger;
    private readonly ICatalogBrandService _catalogBrandService;

    public CatalogBrandController(
        ILogger<CatalogBrandController> logger,
        ICatalogBrandService catalogBrandService)
    {
        _logger = logger;
        _catalogBrandService = catalogBrandService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateBrandResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Create(CreateBrandRequest request)
    {
        var result = await _catalogBrandService.CreateBrandAsync(request.Brand);

        return Ok(new CreateBrandResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(DeleteBrandResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _catalogBrandService.DeleteBrandAsync(id);

        return Ok(new DeleteBrandResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(DeleteBrandResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> DeleteByTitle(string brand)
    {
        var result = await _catalogBrandService.DeleteBrandByTitleAsync(brand);

        return Ok(new DeleteBrandResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(UpdateBrandResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Update(UpdateBrandRequest request)
    {
        var result = await _catalogBrandService.UpdateBrandAsync(request.Id, request.Brand);

        return Ok(new UpdateBrandResponse<int?>() { Id = result });
    }
}
