using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Core.Application.Middlewares;

// Projeye taşındığında bu katman api projesi altında yer alacak. 
// Core.Application projesindan Microsoft.Extensions ve Microsoft.AspNetCore.Http paketleri kaldırılacak.
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        _logger.LogError(ex, ex.Message);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        // Özel hata sınıflarına göre farklı hata mesajları dönebiliriz
        var response = new
        {
            StatusCode = context.Response.StatusCode,
            Message = "Bir hata oluştu. Lütfen daha sonra tekrar deneyin."
        };

        return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
    }
}
