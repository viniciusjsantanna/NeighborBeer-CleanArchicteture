using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NeighborBeer.Application.AutoMapper;
using NeighborBeer.Application.DTOs;
using NeighborBeer.Application.ExceptionStrategy;
using NeighborBeer.Application.Interfaces;
using NeighborBeer.Application.Pipelines;

namespace NeighborBeer.Application.DependencyInjection
{
    public static class ApplicationExtension
    {
        public static IServiceCollection ApplicationRegister(this IServiceCollection services, IConfiguration configuration)
        {
            var mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CustomerMapper());

            });
            mapper.AssertConfigurationIsValid();
            IMapper map = mapper.CreateMapper();

            services.AddSingleton(map);
            services.AddMediatR(typeof(ApplicationExtension).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(ApplicationExtension).Assembly);

            services.AddTransient(typeof(IExceptionHandler<Response>), typeof(NotImplementedExceptionHandler));
            services.AddTransient(typeof(IExceptionHandler<Response>), typeof(ArgumentExceptionHandler));

            return services;
        }
    }
}
