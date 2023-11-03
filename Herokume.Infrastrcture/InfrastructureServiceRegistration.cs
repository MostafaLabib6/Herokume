using Herokume.Application.Contracts.Infrastrcture.EmailService;
using Herokume.Application.Contracts.Infrastrcture.PhotoService;
using Herokume.Application.Models.Mail;
using Herokume.Application.Models.Photo;
using Herokume.Infrastrcture.Mail;
using Herokume.Infrastrcture.Photo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Herokume.Infrastrcture;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSetting>(configuration.GetSection("EmailSettingsConfig"));
        services.AddTransient<IEmailService, EmailService>();

        services.Configure<PhotoSettings>(configuration.GetSection("CloudinarySettings"));
        services.AddTransient<IPhotoService, PhotoService>();

        return services;
    }
}
