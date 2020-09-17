using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NeighborBeer.Application.Interfaces;
using NeighborBeer.Infrastructure.Context;

namespace NeighborBeer.Infrastructure.DependencyInjection
{
    public static class InfraExtension
    {
        public static IServiceCollection InfraRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EFContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SqlConnection"));

            });
            services.AddScoped<IEFContext, EFContext>();
            return services;
        }
    }
}
