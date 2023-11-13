using Herokume.Application.Contracts.Infrastrcture.EmailService;
using Herokume.Application.Models.Mail;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;

namespace Herokume.Infrastrcture.Mail;

public class EmailService : IEmailService
{
    private readonly EmailSetting _emailSettings;

    public EmailService(IOptions<EmailSetting> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }
    public async Task SendEmail(Email email)
    {
        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(_emailSettings.FromAddress, _emailSettings.ApiKey),
            EnableSsl = true,
            UseDefaultCredentials = true
        };

        await smtpClient.SendMailAsync(new MailMessage(from: _emailSettings.FromAddress, to: "abw945424@gmail.com", subject: email.Subject, email.Body));

    }
}
