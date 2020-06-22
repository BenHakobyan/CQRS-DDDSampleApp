using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SampleApp.Domain.Exceptions;
using System;
using System.Threading.Tasks;

namespace SampleApp.Configuration
{
    internal class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this._next.Invoke(context);
            }
            catch (BusinessRuleValidationException ex)
            {
                context.Response.StatusCode = StatusCodes.Status409Conflict;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { message = ex.Message }));
            }
            catch (ModelStateValidationException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { message = ex.Message }));
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { message = "Internal Server Error", details = ex.Message }));
            }
        }
    }
}
