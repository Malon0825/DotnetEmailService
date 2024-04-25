using AutoEmailService.Configurations;
using AutoEmailService.Interface;
using AutoEmailService.Model;
using AutoEmailServiceTest.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutoEmailServiceTest
{
    [TestClass]
    public class ConfigurationTest
    {
        private readonly IConfig _config;
        public ConfigurationTest()
        {
            var serviceProvider = TestInitialize.ServiceProvider ?? throw new NullReferenceException();
            _config = serviceProvider.GetRequiredService<IConfig>();
        }

        [TestMethod]
        public void VersionTest()
        {
            var version = _config.AppVersion();
            Assert.IsTrue(version is not null);
        }


        [TestMethod]
        public void NameTest()
        {
            var name = _config.AppName();
            Assert.IsTrue(name is not null);
        }

        [TestMethod]
        public void MailSettingTest()
        {
            var mailSettings = _config.MailSetting();
            Assert.IsTrue(
                !string.IsNullOrEmpty(mailSettings.Server) &&
                !string.IsNullOrEmpty(mailSettings.Port.ToString()) &&
                !string.IsNullOrEmpty(mailSettings.SenderName) &&
                !string.IsNullOrEmpty(mailSettings.SenderEmail) &&
                !string.IsNullOrEmpty(mailSettings.Password)
                );
        }
    
        [TestMethod]
        public void SettingsTest()
        {
            var configuration = _config.Settings();
    
            var environmentSection = configuration.GetSection("environment");
            var subsections = environmentSection.GetChildren().ToList();
            Assert.IsTrue(subsections.Count > -1);
        }
    }
}
