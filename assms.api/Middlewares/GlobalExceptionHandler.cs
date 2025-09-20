using System.Net;
using System.Net.Mail;
using assms.api.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Serilog;

namespace assms.api.Middlewares;

public class GlobalExceptionHandler : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            Log.Error(
                exception, 
                "Exception caught.\nUser-Agent: {UserAgent}.\nTraceIdentifier: {TraceIdentifier}.\nIp-Address: {IpAddress}",
                context.Request.Headers["User-Agent"].ToString(),
                context.TraceIdentifier,
                context.Connection.RemoteIpAddress?.ToString() ?? "Unknown"
            );
            await HandleException(context, exception);
        }
    }

    private static async Task HandleException(HttpContext context, Exception exception)
    {
        if (exception is AggregateException aggregateException)
        {
            exception = aggregateException.Flatten().InnerExceptions.FirstOrDefault() ?? exception;
        }

        var status = exception switch
        {
            DbUpdateException { InnerException: PostgresException { SqlState: "23505" } } => StatusCodes.Status409Conflict,
            InvalidOperationException => StatusCodes.Status400BadRequest,
            ArgumentException => StatusCodes.Status400BadRequest,
            SmtpException => StatusCodes.Status503ServiceUnavailable,
            KeyNotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        context.Response.StatusCode = status;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = status,
            Detail = SetExceptionMessage(status)
        });
    }

    private static string SetExceptionMessage(int status, string? message = null) => 
        status switch
        {
            (int)HttpStatusCode.NotFound => MessageConstants.NotFoundResource,
            (int)HttpStatusCode.BadRequest => message ?? MessageConstants.InvalidRequest,
            _ => MessageConstants.UnexpectedError
        };
}