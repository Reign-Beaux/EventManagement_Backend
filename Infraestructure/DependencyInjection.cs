using Application.Contracts.Adapters;
using Infraestructure.Adapters;
using Infraestructure.Persistence.EventManagement;
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

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {

            return services;
        }

        private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IEventManagementUnitOfWork, EventManagementUnitOfWork>();

            return services;
        }
    }
}
