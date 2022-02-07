using System.Reflection;

using EasyNetQ;
using EasyNetQ.AutoSubscribe;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure.MessageBus;

public static class UseSubscribeExtenssion
{
    public static IHost UseSubscribe(this IHost host, string subscriptionIdPrefix, Assembly assembly)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var lifeTime = services.GetService<IApplicationLifetime>();
        var bus = services.GetService<IBus>();
        lifeTime.ApplicationStarted.Register(() =>
        {
            var subscriber = new AutoSubscriber(bus, subscriptionIdPrefix);
            subscriber.Subscribe(new[] { assembly }, CancellationToken.None);
            subscriber.SubscribeAsync(new[] { assembly }, CancellationToken.None);
        });

        lifeTime.ApplicationStopped.Register(() => bus.Dispose());

        return host;
    }
}
