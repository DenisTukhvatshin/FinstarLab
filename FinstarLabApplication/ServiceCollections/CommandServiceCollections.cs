using FinstarLab.Application.Commands;
using FinstarLab.Contract.Interfaces.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace FinstarLab.Application.ServiceCollections;

public static class CommandServiceCollections
{
    public static void AddCommands(this IServiceCollection services)
    {
        services.AddScoped<ICodeValueCommand, CodeValueCommand>();
    }
}