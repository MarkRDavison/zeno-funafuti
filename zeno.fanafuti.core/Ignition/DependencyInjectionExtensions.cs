using zeno.fanafuti.core.Data;

namespace zeno.fanafuti.core.Ignition;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddClient(this IServiceCollection services)
    {
        services
            .AddTransient<TitleScene>()
            .AddTransient<GameScene>();

        services
            .AddTransient<MapView>()
            .AddTransient<IslandView>()
            .AddTransient<MilitaryBaseView>();

        services
            .AddScoped<WorldData>();

        services
            .AddScoped<IGameTimeService, GameTimeService>()
            .AddScoped<IMissionGenerator, PeaceTimeMissionGenerator>()
            .AddScoped<IViewNavigationService, ViewNavigationService>();

        return services;
    }
}