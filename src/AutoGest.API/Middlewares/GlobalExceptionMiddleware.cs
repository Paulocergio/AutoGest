using AutoGest.Domain.Exceptions;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace AutoGest.API.Middlewares;

public class GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException ex)
        {
            await WriteResponse(context, HttpStatusCode.BadRequest,
                new { errors = ex.Errors.Select(e => e.ErrorMessage) });
        }
        catch (NotFoundException ex)
        {
            await WriteResponse(context, HttpStatusCode.NotFound,
                new { message = ex.Message });
        }
        catch (DomainException ex)
        {
            await WriteResponse(context, HttpStatusCode.Conflict,
                new { message = ex.Message });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro inesperado");
            await WriteResponse(context, HttpStatusCode.InternalServerError,
                new { message = "Ocorreu um erro interno. Tente novamente mais tarde." });
        }
    }

    private static Task WriteResponse(HttpContext context, HttpStatusCode statusCode, object body)
    {
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(body));
    }
}
