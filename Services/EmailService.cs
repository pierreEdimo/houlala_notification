using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;


namespace notification_service.Services;

public class EmailService(IConfiguration configuration) : IEmailService
{
    public void SendStandardEmail(EmailDto request)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(configuration.GetSection("Username").Value));
        email.To.Add(MailboxAddress.Parse(request.To));
        email.Subject = request.Subject;
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = request.HtmlBody };
        using var smtp = new SmtpClient();
        smtp.Connect(configuration.GetSection("Host").Value, 587, SecureSocketOptions.StartTlsWhenAvailable);
        smtp.Authenticate(configuration.GetSection("Username").Value, configuration.GetSection("Password").Value);
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}