using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Minio;
using PhoneHub.API.Feartures.CategoryFeartures.CreateCategory;
using PhoneHub.API.Feartures.CategoryFeartures.DeleteCategory;
using PhoneHub.API.Feartures.CategoryFeartures.GetCategories;
using PhoneHub.API.Feartures.CategoryFeartures.UpdateCategory;
using PhoneHub.API.Feartures.ProductFeartures.CreateProduct;
using PhoneHub.API.Feartures.ProductFeartures.DeleteProduct;
using PhoneHub.API.Feartures.ProductFeartures.GetProductById;
using PhoneHub.API.Feartures.ProductFeartures.GetProductPage;
using PhoneHub.API.Feartures.ProductFeartures.UpdateProduct;
using PhoneHub.API.Services;
using PhoneHub.API.Settings;

namespace PhoneHub.API;

public static class DependencyInjection
{
    public static void AddAppServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScopes();
        services.AddMinio(configuration);
        services.AddAppDbContext(configuration);
    }

    private static void AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("TestDb"));
        });
    }

    private static void AddScopes(this IServiceCollection services)
    {
        services.AddScoped<IGetProductByIdHandler, GetProductByIdHandler>();
        services.AddScoped<ICreateProductHandler, CreateProductHandler>();
        services.AddScoped<IUpdateProductHandler, UpdateProductHandler>();
        services.AddScoped<IDeleteProductHandler, DeleteProductHandler>();
        services.AddScoped<IGetProductPageHandler, GetProductPageHandler>();
        services.AddScoped<ICreateCategoryHandler, CreateCategoryHandler>();
        services.AddScoped<IDeleteCategoryHandler, DeleteCategoryHandler>();
        services.AddScoped<IGetCategoriesHandler, GetCategoriesHandler>();
        services.AddScoped<IUpdateCategoryHandler, UpdateCategoryHandler>();
        
        
        services.AddScoped<IMinioService, MinioService>();
    }

    private static void AddMinio(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MinioSettings>(configuration.GetSection("Minio"));

        services.AddSingleton(provider =>
        {
            var config = provider.GetRequiredService<IOptions<MinioSettings>>().Value;

            return new MinioClient()
                .WithEndpoint(config.Endpoint)
                .WithCredentials(config.AccessKey, config.SecretKey)
                .WithSSL(config.UseSSL)
                .Build();
        });
    }
}
