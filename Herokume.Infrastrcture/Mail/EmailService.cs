using Azure.Core;
using Herokume.Application.Contracts.Infrastrcture.EmailService;
using Herokume.Application.Models.Mail;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Serilog;
using System.Net;
using System.Net.Mail;

namespace Herokume.Infrastrcture.Mail;

public class EmailService : IEmailService
{
    private readonly EmailSetting _mailSettings;
    private readonly ILogger _logger;

    public EmailService(
        IOptions<EmailSetting> emailSettings,
        ILogger logger
        )
    {
        _mailSettings = emailSettings.Value;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    public async Task SendEmail(Email email)
    {
        //var smtpClient = new SmtpClient("smtp.gmail.com")
        //{
        //    EnableSsl = true,
        //    Credentials = new NetworkCredential(_emailSettings.FromAddress, _emailSettings.ApiKey),
        //    UseDefaultCredentials = false,
        //    Port = 587,

        //};
        //try
        //{
        //    await smtpClient.SendMailAsync(new MailMessage(from: _emailSettings.FromAddress, to: email.To, subject: email.Subject, email.Body));
        //    _logger.Information($"Email sent to {email.To} with subject: {email.Subject}");
        //}
        //catch (Exception ex)
        //{
        //    _logger.Error(ex, "Failed to send email.");
        //}

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_mailSettings.FromAddress, _mailSettings.FromAddress));
        message.To.Add(MailboxAddress.Parse(email.To));
        message.Subject = email.Subject;

        var builder = new BodyBuilder();
        builder.HtmlBody = email.Body;
        message.Body = builder.ToMessageBody();

        using var smtp = new MailKit.Net.Smtp.SmtpClient();
        try
        {
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.FromAddress, _mailSettings.ApiKey);
            await smtp.SendAsync(message);
        }
        catch
        {
            Directory.CreateDirectory("mailssave");
            var emailsavefile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
            await message.WriteToAsync(emailsavefile);
        }

        smtp.Disconnect(true);
    }

}
