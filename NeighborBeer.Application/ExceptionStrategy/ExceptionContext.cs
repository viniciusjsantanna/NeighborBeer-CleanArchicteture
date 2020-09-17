using NeighborBeer.Application.DTOs;
using NeighborBeer.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeighborBeer.Application.ExceptionStrategy
{
    public static class ExceptionContext
    {
        public async static Task<Response> GetExceptionHandlerFromActualException(this Exception exception, IEnumerable<IExceptionHandler<Response>> exceptionHandlers)
        {
            var actualException = exceptionHandlers.Where(e => e.GetType().Name.Contains(exception.GetType().Name)).FirstOrDefault();
            if (actualException != null)
            {
                return await actualException.Handle(exception);
            }

            return await DefaultException();
        }
        private static Task<Response> DefaultException()
        {
            var response = new Response()
            {
                Message = "Houve um error não mapeado, favor entrar em contato com o administrador.",
                StatusCode = System.Net.HttpStatusCode.BadRequest,
            };
            return Task.FromResult(response);
        }
    }
}
