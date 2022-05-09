namespace AbstractCompany.Services
{
    public interface IEmailService
    {
        Task SendConfirmationEmailAsync(string email, string callbackUrl);
        Task SendNotification(string email);
        Task Start();
        Task Stop();
    }
}