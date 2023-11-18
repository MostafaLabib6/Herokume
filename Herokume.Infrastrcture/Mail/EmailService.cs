using Herokume.Application.Contracts.Infrastrcture.EmailService;
using Herokume.Application.Models.Mail;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Core;
using System.Net;
using System.Net.Mail;

namespace Herokume.Infrastrcture.Mail;

public class EmailService : IEmailService
{
    private readonly EmailSetting _emailSettings;
    //private readonly ILogger _logger;

    public EmailService(
        IOptions<EmailSetting> emailSettings
        //ILogger logger
        )
    {
        _emailSettings = emailSettings.Value;
        //_logger = logger;
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
        try
        {
            await smtpClient.SendMailAsync(new MailMessage(from: _emailSettings.FromAddress, to: email.To, subject: email.Subject, email.Body));
        }
        catch (Exception ex)
        {
            //_logger.Error(ex, "Failed to send email.");
        }
    }
}
