using Microsoft.EntityFrameworkCore;

namespace PhoneHub.API;

public static class DependencyInjection
{
    public static void AddAppServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAppDbContext(configuration);
        services.AddScopes();
    }

    private static void AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => {
            options.UseSqlite(configuration.GetConnectionString("TestDb"));
        });
    }

    private static void AddScopes(this IServiceCollection services)
    {
        services.AddScoped<IProductServices, ProductServices>();
    }
}