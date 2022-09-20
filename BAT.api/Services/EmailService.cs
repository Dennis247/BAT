namespace WebApi.Services;

using BAT.api.Helpers;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using SendGrid;
using SendGrid.Helpers.Mail;


public interface IEmailService
{
    void Send(string to, string subject, string html, string from = null);
}

public class EmailService : IEmailService
{
    private readonly AppSettings _appSettings;

    public EmailService(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

   /* public void Send(string to, string subject, string html, string from = null)
    {
        // create message
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(from ?? _appSettings.EmailFrom));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Html) { Text = html };

        // send email
        using var smtp = new SmtpClient();
        smtp.Connect(_appSettings.SmtpHost, _appSettings.SmtpPort, SecureSocketOptions.StartTls);
        smtp.Authenticate(_appSettings.SmtpUser, _appSettings.SmtpPass);
        smtp.Send(email);
        smtp.Disconnect(true);


    }*/

    public void Send(string to, string subject, string html, string from = null)
    {
        var client = new SendGridClient("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");

        var fromx = new EmailAddress("Iyenova2@gmail.com", "Iyenova");
        List<EmailAddress> recipients = new List<EmailAddress>();

      
            recipients.Add(new EmailAddress { Email = to });
        


        var bodyMsg = MailHelper.CreateSingleEmailToMultipleRecipients(fromx, recipients, subject, html, html);

       var result =  client.SendEmailAsync(bodyMsg).Result;
        Console.WriteLine(result);
        
    }

}