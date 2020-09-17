using FluentValidation;
using FluentValidation.Results;
using MediatR;
using NeighborBeer.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NeighborBeer.Application.Pipelines
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest: IRequest<TResponse>
        where TResponse : Response
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                                .Select(x => x.Validate(request))
                                .SelectMany(x => x.Errors)
                                .Where(x => x != null)
                                .ToList();

            return failures.Any() ? Errors(failures) : next();

        }

        private Task<TResponse> Errors(List<ValidationFailure> failures)
        {
            var response = new Response();

            failures.ForEach(e =>
            {
                response.AddErrorMessages(e.ErrorMessage);
            });

            return Task.FromResult(response as TResponse);
        }
    }
}
