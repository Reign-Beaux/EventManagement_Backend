using Application.Interfaces.Adapters;
using Application.Interfaces.Services;
using Domain.UnitOfWork;
using Infraestructure.Adapters;
using Infraestructure.Persistence.EventManagement;
using Infraestructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services
                .AddAdapters()
                .AddServices()
                .AddUnitOfWork();

            return services;
        }

        private static IServiceCollection AddAdapters(this IServiceCollection services)
        {
            services.AddTransient<IEncryptionAdapter, BCryptAdapter>();
            services.AddTransient<IErrorAdapter, ErrorOrAdapter>();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, JWTTokenService>();

            return services;
        }

        private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IEventManagementUnitOfWork, EventManagementUnitOfWork>();

            return services;
        }
    }
}
