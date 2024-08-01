using System.Reflection;
using CLINICAL.UseCase.Commons.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CLINICAL.UseCase.Extensions;

public static class InjectionExtensions
{
    public static IServiceCollection AddInjectionApplication(this IServiceCollection service)
    {
        var asm = Assembly.GetExecutingAssembly();
        service.AddAutoMapper(asm);
        service.AddMediatR(asm);
        service.AddValidatorsFromAssembly(asm);
        service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        return service;
    }
}