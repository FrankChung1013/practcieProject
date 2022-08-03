using Practice.Interface;
using Practice.Repository;
using Practice.Service;

namespace Practice.Extensions;

public static class FeatureServiceExtensions
{
    public static IServiceCollection AddFeatureServiceCollection(this IServiceCollection services)
    {
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IBlogService, BlogService>();

        return services;
    }

}