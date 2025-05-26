using PetrovvEgorkt_31_22.Interfaces;
using System.Runtime.CompilerServices;

namespace PetrovvEgorkt_31_22.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            services.AddScoped<ICathedralService, CathedralService>();
            services.AddScoped<IWorkloadService, WorkloadService>();

            return services;
        }
    }
}
