using Microsoft.AspNetCore.Identity.UI.Services;
using MoneyTransfer.Services.Interface;
using System.Net;
using System.Net.Mail;

namespace MoneyTransfer.Services.Service
{
    public class EmailSender : IEmailSenderService
    {
        private readonly IConfiguration configuration;
        public EmailSender(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string Message)
        {
            SmtpClient smtpClient = new SmtpClient(configuration["EmailSettings:SmtpServer"])
            {
                Port = int.Parse(configuration["EmailSettings:Port"]),
                Credentials = new NetworkCredential(configuration["EmailSettings:Username"], configuration["EmailSettings:Password"]),
                EnableSsl = true,
            };
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(configuration["EmailSettings:SenderEmail"], configuration["EmailSettings:SenderName"]),
                Subject = subject,
                Body = Message,
                IsBodyHtml = true
            };
            mailMessage.To.Add(toEmail);
            try
            {
                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
