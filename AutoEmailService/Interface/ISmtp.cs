namespace AutoEmailService.Interface;
using System.Net.Mail;

public interface ISmtp
{
    SmtpClient MailConnection();
}