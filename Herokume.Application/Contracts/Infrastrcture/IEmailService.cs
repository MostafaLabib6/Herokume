using Herokume.Application.Models.Mail;

namespace Herokume.Application.Contracts.Infrastrcture;

public interface IEmailService
{
    public Task<bool> SendEmail(Email email);
}
