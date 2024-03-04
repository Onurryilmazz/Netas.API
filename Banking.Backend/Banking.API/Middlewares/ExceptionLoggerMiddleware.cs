using System.Net;
using Banking.Application.Models.ResponseModels;
using MediatR;
using Newtonsoft.Json;

namespace Banking.API.Middlewares;

public class ErrorLoggerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorLoggerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IMediator mediator)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, mediator);
        }
    }

    private  static Task HandleExceptionAsync(HttpContext context, Exception ex, IMediator mediator)
    {
        var result = new ServiceResult<Task>();

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var responseEntity = new
        {
            StatusCode = context.Response.StatusCode,
            Message = ex.Message,
        };

        var description = responseEntity.StatusCode + " " + responseEntity.Message;

        // mediator.Send(new LogCommand { Description = description });

        return context.Response.WriteAsync(JsonConvert.SerializeObject(responseEntity));
    }
}
