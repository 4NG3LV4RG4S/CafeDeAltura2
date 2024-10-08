using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Ixhuatlan.Caracolillo.Frontend.Shared;

public static class DependencyContainer
{
    public static IServiceCollection RegisterServicesFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        List<Type> types = assembly
            .GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false } && t.Name.Contains("<") == false)
            .ToList();

        foreach (Type type in types)
        {
            IEnumerable<Type> interfaces = type
                    .GetInterfaces()
                    .Where(i => i.IsGenericType == false || i.IsConstructedGenericType);

            foreach (Type service in interfaces)
            {
                services.TryAddScoped(service, type);
                Console.WriteLine($"Registered: { type.Name } -> { service.Name }");
            }
        }
        return services;
    }
}