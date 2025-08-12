using TravelNurse.Components.Common.Services;

namespace TravelNurse.Components.Common.Utils;

public static class ConfigureTravelNurseService
{
    public static IServiceCollection ConfigureTravelNurseServices(this IServiceCollection services)
    {
        services.AddScoped<IDataFetchService, DataFetchService>();
        return services;
    }
}