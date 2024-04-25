using AutoEmailService.Interface;
using AutoEmailServiceTest.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace AutoEmailServiceTest
{
    [TestClass]
    public class SmtpSetupTest
    {
        private readonly ISmtp _smtpSetup;
        public SmtpSetupTest()
        {
            var serviceProvider = TestInitialize.ServiceProvider ?? throw new NullReferenceException();
            _smtpSetup = serviceProvider.GetRequiredService<ISmtp>();
        }
        
        [TestMethod]
        public void MailConnectionTest()
        {
            var smtpProvider = _smtpSetup.MailConnection();
            Assert.IsTrue(!string.IsNullOrEmpty(smtpProvider.Host) && !string.IsNullOrEmpty(smtpProvider.Port.ToString()) && smtpProvider is { EnableSsl: true, Credentials: not null });
        }
    }
}

