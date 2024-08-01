using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using CLINICAL.UseCase.Commons.Bases;
using ValidationException = CLINICAL.UseCase.Commons.Exceptions.ValidationException;

namespace CLINICAL.Api.Extensions.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (ValidationException ex)
            {
                context.Response.ContentType = "application/json";
                await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object>
                {
                    Message = "Errores de Validación",
                    Errors = ex.Errors
                });
            }
        }
    }
}