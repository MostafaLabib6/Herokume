using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace Herokume.Application
{
    public static class ApplicationServiesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
