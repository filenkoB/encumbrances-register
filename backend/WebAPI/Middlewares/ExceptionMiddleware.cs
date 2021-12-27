using Domain.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Middlewares
{
    public static class ExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            return app;
        }
    }

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AuthorizationException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(GetJsonBody(ex.Message), typeof(object));
            }
            catch (RegistrationException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(GetJsonBody(ex.Message), typeof(object));
            }
            catch (EntityNotFoundException ex)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsJsonAsync(GetJsonBody(ex.Message), typeof(object));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(
                    GetJsonBody("Наразі сервер не може обробити ваш запит. Просимо звернутися до системного адміністратора"),
                    typeof(string)
                );
            }
        }

        private object GetJsonBody(string exMessage)
        {
            return new
            {
                Error = exMessage
            };
        }
    }
}
