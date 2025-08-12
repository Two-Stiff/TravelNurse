using TravelNurseServer.Services;

namespace TravelNurseServer.Common;

public static class ConfigurationService
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IDisciplineService, DisciplineService>();
        services.AddScoped<IJobService, JobService>();
        services.AddScoped<IProviderService, ProviderService>();

        return services;
    }
}