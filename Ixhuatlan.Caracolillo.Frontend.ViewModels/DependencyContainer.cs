using System.Reflection;
using Ixhuatlan.Caracolillo.Frontend.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Ixhuatlan.Caracolillo.Frontend.ViewModels;

public static class DependencyContainer
{
    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        return services.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    }
}