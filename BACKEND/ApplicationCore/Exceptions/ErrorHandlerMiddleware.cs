using Domain.Core;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace ApplicationCore.Exceptions
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AccessViolationException avEx)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var message = avEx switch
                {
                    AccessViolationException => "Access violation error from the custom middleware",
                    _ => "Internal Server Error from the custom middleware."
                };
                var responseModel = new HttpResponseResult { Code = (int)HttpStatusCode.InternalServerError, Success = false, Message = message };
                responseModel.Errors = new List<string> { message };
                var result = JsonSerializer.Serialize(responseModel);
                Console.WriteLine(result);
                await context.Response.WriteAsync(result);
            }
            catch (Exception error)
            {
                var httpStatusCode = HttpStatusCode.InternalServerError;
                var response = context.Response;
                context.Response.ContentType = "application/json";
                var errorResponse = new HttpResponseResult { Code = (int)HttpStatusCode.InternalServerError, Success = false, Message = error.Message };
                var result = string.Empty;

                switch (error)
                {
                    case ApiException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        errorResponse.Code = (int)HttpStatusCode.BadRequest;
                        errorResponse.Message = e.Message;
                        break;
                    case ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.VariantAlsoNegotiates;
                        errorResponse.Code = (int)HttpStatusCode.VariantAlsoNegotiates;
                        errorResponse.Message = e.Errors.FirstOrDefault() ?? e.Message;
                        errorResponse.Errors = e.Errors;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        errorResponse.Code = (int)HttpStatusCode.NotFound;
                        errorResponse.Message = e.Message;
                        errorResponse.Errors = new List<string> { e.InnerException.Message ?? "" };
                        break;
                }

                context.Response.StatusCode = (int)httpStatusCode;

                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                };

                result = JsonSerializer.Serialize(errorResponse, serializeOptions);
                await response.WriteAsync(result);
            }
        }
    }
}
