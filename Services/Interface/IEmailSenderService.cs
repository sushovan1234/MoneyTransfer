namespace MoneyTransfer.Services.Interface
{
    public interface IEmailSenderService
    {
        Task<bool> SendEmailAsync(string toEmail, string subject, string Message);
    }
}
