using AbstractCompany.Identity.Models;
using AbstractCompany.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Quartz;

namespace AbstractCompany.Notification
{
    public class NotificationsJob : IJob
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        private readonly ILogger<NotificationsJob> _logger;

        public NotificationsJob(
            UserManager<User> userManager,
            IEmailService emailService, 
            ILogger<NotificationsJob> logger)
        {
            _userManager = userManager;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var list = _userManager.Users.Where(s => s.EmailConfirmed);

            await _emailService.Start();

            foreach(var user in list)
            {
                await _emailService.SendNotification(user.Email);
            }

            await _emailService.Stop();

            _logger.LogInformation("Уведомления отправлены");
        }
    }
}
