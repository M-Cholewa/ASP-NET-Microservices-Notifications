using System.Net;
using System.Text.Json;
using Notify.Contracts.Shared;
using Notify.Domain.SeedWork;

namespace Notify.API.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (BusinessRuleValidationException ex)
        {
            await HandleBusinessRuleExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleBusinessRuleExceptionAsync(HttpContext context, BusinessRuleValidationException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var response = new ErrorDto(exception.Message, exception.Details);

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new ErrorDto("An error occurred, but don't panic :)", exception.Message);

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}