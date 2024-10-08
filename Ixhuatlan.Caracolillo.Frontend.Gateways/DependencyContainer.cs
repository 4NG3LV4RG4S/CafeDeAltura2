using System.Reflection;
using Ixhuatlan.Caracolillo.Frontend.Interfaces.System.Responses;
using Ixhuatlan.Caracolillo.Frontend.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Ixhuatlan.Caracolillo.Frontend.Gateways;

public static class DependencyContainer
{
    public static IServiceCollection AddGatewayServices(this IServiceCollection services)
    {
        services.AddTransient<IProcessResponse, ProcessResponse>();
        return services.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    }
}