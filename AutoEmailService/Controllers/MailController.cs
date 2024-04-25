using AutoEmailService.Model;
using Microsoft.AspNetCore.Mvc;
using AutoEmailService.Interface;

namespace AutoEmailService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MailController(IMailService mailService, ILogger<MailController> logger) : ControllerBase
    {
        [HttpPost]
        [Route("/Mail/SendEmail")]
        public bool SendEmail(MailData mailData)
        {
            try
            {
                logger.LogInformation("Email sending on progress...");
                bool result = mailService.SendMail(mailData);
                logger.LogInformation(result ? "Email sent successfully" : "Failed to send email");
                return result;
            }
            catch (Exception ex)
            {
                logger.LogError("Email service has encountered and error!!");
                logger.LogError(ex.Message);
                return false;
            }         
        }
    }
}
