using AutoEmailService.Model;
using AutoEmailServiceTest.Utilities;
using AutoEmailService.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace AutoEmailServiceTest
{
    [TestClass]
    public class MailServiceTest
    {
        private readonly MailData _mailData = new();
        private readonly PopulateMailData _populateMailData;
        private readonly IMailService _mailService;

        public MailServiceTest()
        {
            var serviceProvider = TestInitialize.ServiceProvider ?? throw new NullReferenceException();
            _mailService = serviceProvider.GetRequiredService<IMailService>();
            _populateMailData = serviceProvider.GetRequiredService<PopulateMailData>();
        }

        [TestMethod]
        public void SendMailTest()
        {
            _mailData.EmailSubject = "Unit Testing Subject";
            _mailData.EmailBody = "Unit Testing Body";
            _mailData.EmailToTable = _populateMailData.SetEmailRecipient();

            var res = _mailService.SendMail(_mailData);
           Assert.IsTrue(res);
        }
    }
}
