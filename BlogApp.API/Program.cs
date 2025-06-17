using System.Reflection;
using BlogApp.Business;
using BlogApp.Core.Entities;
using BlogApp.DAL;
using BlogApp.DAL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddOpenApi();
        
        builder.Services.AddBusinessService();
        builder.Services.AddDALService();

        builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
        {
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequiredLength = 4;
        }).AddEntityFrameworkStores<BlogAppDbContext>().AddDefaultTokenProviders();

        builder.Services.AddDbContext<BlogAppDbContext>(opt=>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
        });
        
        
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapOpenApi();

        }
        
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        
        
        app.Run();
    }
}