using Herokume.Application.AutoMapper;
using Herokume.Application.Contracts.Infrastrcture.EmailService;
using Herokume.Application.Models.Mail;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace Herokume.Application
{
    public static class ApplicationServiesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
