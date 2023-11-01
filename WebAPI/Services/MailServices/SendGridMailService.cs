using SendGrid.Helpers.Mail;
using SendGrid;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Web;

namespace WebAPI.Services.MailService
{
    public class SendGridMailService : IMailService
    {
        private readonly ISendGridClient _client;

        public SendGridMailService(ISendGridClient client)
        {
            _client = client;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            var from = new EmailAddress("mariuszpaluch001@gmail.com", "Online shop project");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            var response = await _client.SendEmailAsync(msg);
        }
    }
}
