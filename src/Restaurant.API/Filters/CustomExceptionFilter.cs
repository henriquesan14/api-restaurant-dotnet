﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Restaurant.Core.Exceptions;
using System.Net;

namespace Restaurant.API.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var statusCode = (int) HttpStatusCode.InternalServerError; // Status code padrão para outras exceções

            if (exception is NotFoundException)
            {
                statusCode = (int) HttpStatusCode.NotFound; // Se for uma KeyNotFoundException, define o status code como 404
            }
            else if (exception is UserAlreadyExistsException)
            {
                statusCode = (int) HttpStatusCode.Conflict; // Se for uma InvalidOperationException, define o status code como 400
            }
            // Aqui você pode adicionar mais blocos para outros tipos de exceções e definir status code diferentes conforme necessário

            var result = new ObjectResult(new
            {
                StatusCode = statusCode,
                Message = exception.Message // Retorna a mensagem da exceção
            })
            {
                StatusCode = statusCode
            };

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
