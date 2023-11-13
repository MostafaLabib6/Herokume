using Herokume.Application.Models.Mail;

namespace Herokume.Application.Contracts.Infrastrcture.EmailService;

public interface IEmailService
{
    public Task SendEmail(Email email);
}
