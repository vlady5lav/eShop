using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogTypeController : ControllerBase
{
    private readonly ILogger<CatalogTypeController> _logger;
    private readonly ICatalogTypeService _catalogTypeService;

    public CatalogTypeController(
        ILogger<CatalogTypeController> logger,
        ICatalogTypeService catalogTypeService)
    {
        _logger = logger;
        _catalogTypeService = catalogTypeService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateTypeResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Create(CreateTypeRequest request)
    {
        var result = await _catalogTypeService.CreateTypeAsync(request.Type);

        return Ok(new CreateTypeResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(DeleteTypeResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _catalogTypeService.DeleteTypeAsync(id);

        return Ok(new DeleteTypeResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(DeleteTypeResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> DeleteByTitle(string type)
    {
        var result = await _catalogTypeService.DeleteTypeByTitleAsync(type);

        return Ok(new DeleteTypeResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(UpdateTypeResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> Update(UpdateTypeRequest request)
    {
        var result = await _catalogTypeService.UpdateTypeAsync(request.Id, request.Type);

        return Ok(new UpdateTypeResponse<int?>() { Id = result });
    }
}
