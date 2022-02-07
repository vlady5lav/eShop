using EasyNetQ;

namespace Infrastructure.MessageBus;

[Queue("MessageOrder.Status", ExchangeName = "MessageOrder.Status")]
public class MessageOrderStatus
{
    public OrderStatus Status { get; set; }

    public string UserId { get; set; } = null!;
}
