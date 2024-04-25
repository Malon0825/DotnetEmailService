using AutoEmailService.Model;
using System.Net;
using System.Net.Mail;
using AutoEmailService.Interface;

namespace AutoEmailService.Configurations
{
    public class SmtpSetup : ISmtp
    {
        private readonly IConfig _config;
        public SmtpSetup(IConfig config)
        {
            _config = config;
        }
        
        public SmtpClient MailConnection()
        {
            SmtpClient smtpClient = new();
            smtpClient.Host = _config.MailSetting().Server ?? throw new InvalidOperationException();
            smtpClient.Port = _config.MailSetting().Port;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(
                _config.MailSetting().SenderName,
                _config.MailSetting().Password
            );
            return smtpClient;
        }
    }
}
