using SendGrid.Helpers.Mail;
using SendGrid;

namespace WebAPI.Services.MailService
{
    public interface IMailService
    {

        Task SendEmailAsync(string toEmail, string subject, string content);

    }
    
}
