using AutoEmailService.Interface;
using AutoEmailService.Model;

namespace AutoEmailService.Configurations
{
    public class Configuration : IConfig
    {

        public string AppVersion()
        {
            var version = Settings().GetSection("AppVersion");
            return version.Value ?? throw new ArgumentNullException($"App version configuration section is missing.");
        }

        public string AppName()
        {
            var version = Settings().GetSection("AppName");
            return version.Value ?? throw new ArgumentNullException($"App name configuration section is missing.");
        }

        public MailSettings MailSetting()
        {
            MailSettings mailSettings = new();
            var mailSettingSection = Settings().GetSection("MailSettings");

            mailSettings.Server = mailSettingSection.GetValue<string>("Server") ?? throw new NullReferenceException($"MailSettings does not provide Server section or empty.");

            mailSettings.Port = mailSettingSection.GetValue<int>("Port");

            mailSettings.SenderName = mailSettingSection.GetValue<string>("SenderName") ?? throw new NullReferenceException($"MailSettings does not provide SenderName section or empty.");

            mailSettings.SenderEmail = mailSettingSection.GetValue<string>("SenderEmail") ?? throw new NullReferenceException($"MailSettings does not provide SenderEmail section or empty.");

            mailSettings.Password = mailSettingSection.GetValue<string>("Password") ?? throw new NullReferenceException($"MailSettings does not provide Password section or empty.");

            return mailSettings;
        }

        public IConfigurationRoot Settings()
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();

            return configuration;
        }      
    }
}
