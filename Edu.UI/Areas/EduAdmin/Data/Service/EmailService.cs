using EduApp.Helpers;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System.Management;



namespace EduApp.Areas.EduAdmin.Data.Service;

public class EmailService : IEmailService
{
    private readonly EmailSetting _emailSettings;

    public EmailService(IOptions<EmailSetting> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }
    public void Send(string to, string subject, string html, string form = null)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(form ?? _emailSettings.FormAddres));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = html };

        using var smtp = new SmtpClient();
        smtp.Connect(_emailSettings.Server, _emailSettings.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(_emailSettings.UserName, _emailSettings.Password);
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}
