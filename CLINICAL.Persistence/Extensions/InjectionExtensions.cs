using CLINICAL.Interface;
using CLINICAL.Persistence.Context;
using CLINICAL.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CLINICAL.Persistence.Extensions;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjectionPersistence(this IServiceCollection service)
    {
        service.AddSingleton<ApplicationDbContext>();
        service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        service.AddTransient<IUnitOfWork, UnitOfWork>();
        return service;
    }
}