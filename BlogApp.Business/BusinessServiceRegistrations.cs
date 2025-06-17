using BlogApp.Business.DTOs.Category;
using BlogApp.Business.Services.Implementations;
using BlogApp.Business.Services.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApp.Business;

public static class BusinessServiceRegistrations
{
    public static void AddBusinessService(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BusinessServiceRegistrations));
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IUserService, UserService>();
        services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCategoryDtoValidator>());
    }
}