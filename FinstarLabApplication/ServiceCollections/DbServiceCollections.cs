using FinStarLab.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinstarLab.Application.ServiceCollections;

public static class DbServiceCollections
{
    public static void AddDbPostgreSql(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FinstarLabContext>(options => options
            .UseNpgsql(configuration.GetConnectionString("PostgreSQL.FinstarLabDb-Dev")));
    }
}