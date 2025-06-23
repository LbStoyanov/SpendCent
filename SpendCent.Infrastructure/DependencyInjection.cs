using Microsoft.Extensions.DependencyInjection;
using SpendCent.Core.RepositoryContracts;
using SpendCent.Infrastructure.DbContext;
using SpendCent.Infrastructure.Repositories;

namespace SpendCent.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUsersRepository, UsersRepository>();
        services.AddTransient<DapperDbContext>();

        return services;
    }

}