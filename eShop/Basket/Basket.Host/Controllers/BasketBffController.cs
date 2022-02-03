using Basket.Host.Models;
using Basket.Host.Services.Interfaces;

namespace Basket.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class BasketBffController : ControllerBase
{
    private readonly IBasketService _basketService;

    private readonly ILogger<BasketBffController> _logger;

    public BasketBffController(
        ILogger<BasketBffController> logger,
        IBasketService basketService)
    {
        _logger = logger;
        _basketService = basketService;
    }

    [HttpPost]
    [RateLimit]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.TooManyRequests)]
    public async Task<IActionResult> TestAdd(TestAddRequest data)
    {
        var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        await _basketService.TestAdd(basketId!, data.Data);
        return Ok();
    }

    [HttpPost]
    [RateLimit]
    [ProducesResponseType(typeof(TestGetResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.TooManyRequests)]
    public async Task<IActionResult> TestGet()
    {
        var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        var response = await _basketService.TestGet(basketId!);
        return Ok(response);
    }
}
