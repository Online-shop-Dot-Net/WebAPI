using SendGrid.Helpers.Mail;
using SendGrid;

namespace WebAPI.Services.MailService
{
    public class SendGridMailService : IMailService
    {

        public SendGridMailService()
        {
        }

        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            var apiKey = Environment.GetEnvironmentVariable("SEND_GRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("mariuszpaluch001@gmail.com", "JWT Auth Demo");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
