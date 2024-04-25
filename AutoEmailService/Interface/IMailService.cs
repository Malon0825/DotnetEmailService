using AutoEmailService.Controllers;
using AutoEmailService.Model;

namespace AutoEmailService.Interface
{
    public interface IMailService
    {
        bool SendMail(MailData mailData);
    }
}
