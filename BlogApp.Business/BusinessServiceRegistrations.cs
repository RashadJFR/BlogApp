using BlogApp.Business.Services.Implementations;
using BlogApp.Business.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.Business;

public static class BusinessServiceRegistrations
{
    public static void AddBusinessService(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BusinessServiceRegistrations));
        services.AddScoped<ICategoryService, CategoryService>();
    }
}