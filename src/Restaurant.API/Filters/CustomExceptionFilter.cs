using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Exceptions;
using System.Net;

namespace Restaurant.API.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var message = exception.Message;

            if (exception is NotFoundException)
            {
                statusCode = (int)HttpStatusCode.NotFound; // Se for uma KeyNotFoundException, define o status code como 404
            }
            else if (exception is UserAlreadyExistsException)
            {
                statusCode = (int)HttpStatusCode.Conflict;
            }
            else if (exception is UnauthorizedException)
            {
                statusCode = (int)HttpStatusCode.Unauthorized;
            }
            else if (exception is DbUpdateException dbUpdateException)
            {
                statusCode = (int)HttpStatusCode.Conflict;

                var innerExceptionMessage = GetInnerMostExceptionMessage(dbUpdateException);
                if (innerExceptionMessage.Contains("violates foreign key constraint"))
                {
                    message = "Não é possível deletar a entidade porque ela está relacionada a outras entidades.";
                }
                else
                {
                    message = "Ocorreu um erro ao atualizar o banco de dados. Por favor, tente novamente.";
                }
            }

            var result = new ObjectResult(new
            {
                StatusCode = statusCode,
                Message = message
            })
            {
                StatusCode = statusCode
            };

            context.Result = result;
            context.ExceptionHandled = true;
        }

        private string GetInnerMostExceptionMessage(Exception ex)
        {
            var innerEx = ex;
            while (innerEx.InnerException != null)
            {
                innerEx = innerEx.InnerException;
            }
            return innerEx.Message;
        }
    }
}
