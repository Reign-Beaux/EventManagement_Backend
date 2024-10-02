using Domain.UnitOfWork;
using Infraestructure.Persistence.EventManagement;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddTransient<IEventManagementUnitOfWork, EventManagementUnitOfWork>();

            return services;
        }
    }
}
