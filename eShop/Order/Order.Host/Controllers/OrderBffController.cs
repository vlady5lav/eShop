using Order.Host.Models;
using Order.Host.Services.Interfaces;

namespace Order.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class OrderBffController : ControllerBase
{
    private readonly ILogger<OrderBffController> _logger;

    private readonly IOrderService _orderService;

    public OrderBffController(
        ILogger<OrderBffController> logger,
        IOrderService orderService)
    {
        _logger = logger;
        _orderService = orderService;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> Test(TestRequest data)
    {
        var userId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        await _orderService.Test(userId, data.Data);
        return Ok();
    }
}
