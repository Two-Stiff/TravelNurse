using TravelNurseServer.Services;

namespace TravelNurseServer.Common;

public static class ConfigurationService
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IDisciplineService, DisciplineService>();

        return services;
    }
}