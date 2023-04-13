using Kontent.Bridge.QueueOverview.Application.Contracts.Persistence;
using Kontent.Bridge.QueueOverview.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Kontent.Bridge.QueueOverview.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IMessagesRepository, CosmosMessagesRepository>();
        }
    }
}
