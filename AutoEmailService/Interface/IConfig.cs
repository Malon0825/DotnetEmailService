namespace AutoEmailService.Interface;
using Model;

public interface IConfig
{
    string AppVersion();
    string AppName();
    MailSettings MailSetting();
    IConfigurationRoot Settings();
}