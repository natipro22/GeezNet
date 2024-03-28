using GeezNet.Convertor;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GeezNet;
public static class Startup
{
    public static IServiceCollection AddGeezNet(this IServiceCollection services)
    {
        services.AddScoped<IAsciiConvertor, AsciiConvertor>();
        services.AddScoped<IGeezConvertor, GeezConvertor>();
        services.AddScoped<IGeez, Geez>();
        return services;
    }
}
