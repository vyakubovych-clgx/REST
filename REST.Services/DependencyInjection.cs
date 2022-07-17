using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using REST.DataAccess;
using REST.DataAccess.Context;
using REST.DataAccess.Interfaces;
using REST.Services.Interfaces;
using REST.Services.Services;

namespace REST.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services)
    {
        services.AddDbContext<CatalogDbContext>(options => options.UseInMemoryDatabase("Catalog"));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }

    public static IServiceCollection SeedInMemoryDatabase(this IServiceCollection services)
    {
        using var provider = services.BuildServiceProvider();
        DataGenerator.Initialize(provider);
        return services;
    }

    public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped(_ =>
            new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile())).CreateMapper());
        return services;
    }
}