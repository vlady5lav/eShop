using Infrastructure.MessageBus;

using Order.Host.Services.Interfaces;

namespace Order.Host.Services;

public class OrderService : IOrderService
{
    private readonly IBus _bus;

    public OrderService(IBus bus)
    {
        _bus = bus;
    }

    public async Task Test(string userId, string data)
    {
        //TODO: some logic with data
        try
        {
            await _bus.SendReceive.SendAsync(
                nameof(MessageOrderStatus),
                new MessageOrderStatus
                {
                    Status = OrderStatus.Created,
                    UserId = userId
                });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
