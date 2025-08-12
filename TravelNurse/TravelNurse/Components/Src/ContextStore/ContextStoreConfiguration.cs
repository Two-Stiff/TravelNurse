using TravelNurse.Components.Src.Tables;

namespace TravelNurse.Components.Src.ContextStore;

public static class ContextStoreConfiguration
{
    public static IServiceCollection ConfigureContextStoreServices(this IServiceCollection services)
    {
        services.AddScoped<AllProviderTableStore>();
        services.AddScoped<JobTableStore>();
        return services;
    }
}