using AutoEmailServiceTest.Utilities;
using Microsoft.Extensions.DependencyInjection;
using AutoEmailService.Interface;
using AutoEmailService.Logic;
using AutoEmailService.Configurations;


namespace AutoEmailServiceTest.Utilities
{
    [TestClass]
    public static class TestInitialize
    {
        public static IServiceProvider? ServiceProvider { get; set; }

        [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            // Register your dependencies here
            services.AddSingleton<IConfig, Configuration>();
            services.AddSingleton<ISmtp, SmtpSetup>();
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<PopulateMailData>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
