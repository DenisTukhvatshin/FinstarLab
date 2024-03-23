using FinstarLab.Application.Queries;
using FinstarLab.Contract.Interfaces.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace FinstarLab.Application.ServiceCollections;

public static class QueryServiceCollections
{
    public static void AddQueries(this IServiceCollection services)
    {
        services.AddScoped<ICodeValueQuery, CodeValueQuery>();
    }
}