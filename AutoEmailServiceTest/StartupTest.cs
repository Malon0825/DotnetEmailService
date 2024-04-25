using AutoEmailService.Configurations;
using AutoEmailService.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace AutoEmailServiceTest
{
    [TestClass]
    public class StartupTest
    {
        [TestMethod]
        public void ConfigureServicesTest()
        {
            var services = new ServiceCollection();
            new Startup().ConfigureServices(services);
            var mailServiceDescriptor = services.FirstOrDefault(s => s.ServiceType == typeof(IMailService));
            var configDescriptor = services.FirstOrDefault(s => s.ServiceType == typeof(IConfig));
            
            Assert.IsNotNull(mailServiceDescriptor);
            Assert.IsNotNull(configDescriptor);
            Assert.AreEqual(ServiceLifetime.Transient,mailServiceDescriptor.Lifetime);
            Assert.AreEqual(ServiceLifetime.Singleton, configDescriptor.Lifetime);
        }

        [TestMethod]
        public void LoggerTest()
        {
            var services = new ServiceCollection();
            new Startup().ConfigureServices(services);
            var loggerServiceDescriptor = services.FirstOrDefault(s => s.ServiceType == typeof(Logger<>));
            
            Assert.IsNull(loggerServiceDescriptor);
        }

    }
}
