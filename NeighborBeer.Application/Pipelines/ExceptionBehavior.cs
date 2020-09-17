using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NeighborBeer.Application.DTOs;
using NeighborBeer.Application.ExceptionStrategy;
using NeighborBeer.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NeighborBeer.Application.Pipelines
{
    public class ExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : Response
    {
        private readonly IEnumerable<IExceptionHandler<Response>> _exceptionHandlers;

        public ExceptionBehavior(IEnumerable<IExceptionHandler<Response>> exceptionHandlers)
        {
            _exceptionHandlers = exceptionHandlers;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                return await ex.GetExceptionHandlerFromActualException(_exceptionHandlers) as TResponse;
            }
        }
    }
}
