using Microsoft.Extensions.DependencyInjection;
using SpendCent.Core.ServiceContracts;
using SpendCent.Core.Services;

namespace SpendCent.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddTransient<IUsersService, UserService>();

        return services;
    }

}