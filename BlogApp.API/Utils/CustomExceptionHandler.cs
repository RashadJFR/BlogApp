using System.Net.Mime;
using BlogApp.Business.Exceptions.Base;
using Microsoft.AspNetCore.Diagnostics;

namespace BlogApp.API.Utils;

public static class CustomExceptionHandler
{
    public static void UseCustomExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(exceptionHandlerApp =>
        {
            exceptionHandlerApp.Run(async context =>
            {
                int statusCode = 500;

                // using static System.Net.Mime.MediaTypeNames;
                context.Response.ContentType = MediaTypeNames.Text.Plain;

                var exceptionHandlerPathFeature =
                    context.Features.Get<IExceptionHandlerPathFeature>();
                
                if (exceptionHandlerPathFeature?.Error is IBaseException ex)
                {
                    statusCode = ex.StatusCode != 0 ? ex.StatusCode : 500;
                    context.Response.StatusCode = statusCode;

                    await context.Response.WriteAsJsonAsync(new
                    {
                        StatusCode = statusCode,
                        Message = ex.ErrorMessage
                    });

                }
                else
                {
                    statusCode = StatusCodes.Status500InternalServerError;
                    context.Response.StatusCode = statusCode;
                    
                    await context.Response.WriteAsJsonAsync(new
                    {
                        StatusCode = statusCode,
                        Message = "Unexpected error occurred"
                    });
                }
                
                if (exceptionHandlerPathFeature?.Path == "/")
                {
                    await context.Response.WriteAsync(" Page: Home.");
                }
                
            });
        });
    }
}