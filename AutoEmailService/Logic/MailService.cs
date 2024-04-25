using AutoEmailService.Model;
using AutoEmailService.Interface;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Net.Mail;
using AutoEmailService.Enum;

namespace AutoEmailService.Logic
{
    public class MailService : IMailService
    {
        private readonly ISmtp _smtpSetup;
        private readonly ILogger _logger;
        private readonly IConfig _config;

        public MailService(ILogger<MailService> logger, IConfig config, ISmtp smtpSetup)
        {
            _smtpSetup = smtpSetup;
            _logger = logger;
            _config = config;
        }

        public bool SendMail(MailData mailData)
        {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, policyErrors) => true;
            _logger.LogInformation("Preparing email contents...");
            MailMessage mailMessage = new()
            {
                From = new MailAddress(_config.MailSetting().SenderEmail),
                Subject = mailData.EmailSubject,
                Body = mailData.EmailBody
            };
            _logger.LogInformation($"Email Subject: {mailData.EmailSubject}");

            _logger.LogInformation("Sorting email recipients...");
            if (mailData.EmailToTable is null) throw new ArgumentNullException($"{mailData}");
            var emailToTable = JsonConvert.DeserializeObject<DataTable>(mailData.EmailToTable);
            var rows = (emailToTable?.AsEnumerable()) ?? throw new NullReferenceException();
            foreach (var row in rows)
            {
                var recipientType = Convert.ToInt32(row["TO_IND"]);
                var emailAddress = row["EMAIL_ADDRESS"].ToString() ?? throw new NullReferenceException();
                _logger.LogInformation($"Email to: {emailAddress}");

                switch (recipientType)
                {
                    case (int)Indicator.Cc:
                        mailMessage.CC.Add(emailAddress);
                        break;
                    case (int)Indicator.To:
                        mailMessage.To.Add(emailAddress);
                        break;
                    case (int)Indicator.Bcc:
                        mailMessage.Bcc.Add(emailAddress);
                        break;
                    default:
                        throw new Exception("No indicator that correspond to the given number.");
                }
            }

            _logger.LogInformation("Preparing host, port, and network credentials...");
            var smtpClient = _smtpSetup.MailConnection();

            _logger.LogInformation("Sending email to clients...");
            smtpClient.Send(mailMessage);
            return true;
        }
    }
}
