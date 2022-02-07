namespace Order.Host.Services.Interfaces;

public interface IOrderService
{
    Task Test(string userId, string data);
}
