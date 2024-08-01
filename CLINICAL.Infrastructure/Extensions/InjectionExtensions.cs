using CLINICAL.Infrastructure.Authentication;
using CLINICAL.Interface.Autthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CLINICAL.Infrastructure.Extensions;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjectionInfraestructure
    (this IServiceCollection services,
    ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        
        return services;
    }
}