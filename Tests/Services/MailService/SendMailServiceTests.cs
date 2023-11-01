using Moq;
using SendGrid;
using SendGrid.Helpers.Mail;
using WebAPI.Services.MailService;
using Xunit;

namespace WebAPI.Tests.Services.MailService
{
    public class ProcessEmailTests
    {
        private readonly Mock<ISendGridClient> _mockSendGridClient = new Mock<ISendGridClient>();
        private SendGridMailService _sendGridMailService;

        public ProcessEmailTests()
        {
            _sendGridMailService = new SendGridMailService(_mockSendGridClient.Object);
        }

        [Fact]
        public async Task CheckMailSending()
        {
            var toEmail = "test@test.com";
            var subject = "Test";
            var content = "Test-content";
            await _sendGridMailService.SendEmailAsync(toEmail, subject, content);
            _mockSendGridClient
                .Verify(sg => sg.SendEmailAsync(
                    It.Is<SendGridMessage>(sgm => sgm.Personalizations[0].Tos[0].Email == toEmail), 
                    It.IsAny<CancellationToken>()
                ), Times.Once);

        }

    }
}
