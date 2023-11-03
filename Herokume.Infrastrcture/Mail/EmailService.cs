using Herokume.Application.Contracts.Infrastrcture.EmailService;
using Herokume.Application.Models.Mail;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;


namespace Herokume.Infrastrcture.Mail;

public class EmailService : IEmailService
{
    private readonly EmailSetting _emailSettings;

    public EmailService(IOptions<EmailSetting> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }
    public async Task<bool> SendEmail(Email email)
    {
        var client = new SendGridClient(_emailSettings.ApiKey);

        var to = new EmailAddress(email.To);
        var from = new EmailAddress(_emailSettings.FromAddress, _emailSettings.FromName);
        var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);

        var response = await client.SendEmailAsync(message);

        return response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted;
    }
}
