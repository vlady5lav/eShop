using Basket.Host.Services.Interfaces;

namespace Basket.Host.Consumers;

public class MessageOrderStatusConsumers : IConsumeAsync<MessageOrderStatus>
{
    private readonly IBasketService _basketService;

    private readonly ILogger<MessageOrderStatusConsumers> _logger;

    public MessageOrderStatusConsumers(
        ILogger<MessageOrderStatusConsumers> logger,
        IBasketService basketService)
    {
        _logger = logger;
        _basketService = basketService;
    }

    public async Task ConsumeAsync(MessageOrderStatus message, CancellationToken cancellationToken = default(CancellationToken))
    {
        if (message.Status == OrderStatus.Created)
        {
            await _basketService.TestRemove(message.UserId);
            _logger.LogInformation($"Order was created for user with id {message.UserId}");
        }
    }
}
