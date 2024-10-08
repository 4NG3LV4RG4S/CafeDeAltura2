using Ixhuatlan.Caracolillo.Frontend.Entities.Options;
using Ixhuatlan.Caracolillo.Frontend.Gateways;
using Ixhuatlan.Caracolillo.Frontend.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MudBlazor;
using MudBlazor.Services;

namespace Ixhuatlan.Caracolillo.Frontend.IoC;

public static class DependencyContainer
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddGatewayServices()
            .AddViewModels()
            .AddHttpClient()
            .AddMudServices()
            .Configure<CaracolilloOptions>(configuration.GetSection(CaracolilloOptions.SectionKey));

        services.AddHttpClient("CaracolilloClient", (provider, client) =>
        {
            client.BaseAddress = new Uri(provider.GetRequiredService<IOptions<CaracolilloOptions>>().Value
                .CaracolilloBaseAddres);
            client.Timeout = TimeSpan.FromMinutes(1);
        });

        services.AddMudServices(config =>
        {
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopEnd;
            config.SnackbarConfiguration.PreventDuplicates = false;
            config.SnackbarConfiguration.NewestOnTop = false;
            config.SnackbarConfiguration.ShowCloseIcon = true;
            config.SnackbarConfiguration.VisibleStateDuration = 10000;
            config.SnackbarConfiguration.HideTransitionDuration = 400;
            config.SnackbarConfiguration.ShowTransitionDuration = 400;
            config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
        });

        return services;
    }
}