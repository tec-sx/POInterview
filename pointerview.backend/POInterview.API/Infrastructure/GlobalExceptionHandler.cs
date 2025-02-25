﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using POInterview.Application.Exceptions;

namespace POInterview.API.Infrastructure;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "An unhandled exception has occurred: {Message}", exception.Message);

        int statusCode = StatusCodes.Status500InternalServerError;

        switch (exception)
        {
            case ArgumentException _:
                statusCode = StatusCodes.Status400BadRequest;
                break;
            case InvalidBookingException _:
                statusCode = StatusCodes.Status409Conflict;
                break;
        }

        var problemDetails = new ProblemDetails
        {
            Title = "Server error",
            Status = statusCode,
            Detail = exception.Message
        };

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
