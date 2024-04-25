using Microsoft.OpenApi.Models;
using Serilog;
using AutoEmailService.Logic;
using AutoEmailService.Interface;

namespace AutoEmailService.Configurations
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IMailService, MailService>();
            services.AddSingleton<IConfig, Configuration>();
            services.AddSingleton<ISmtp, SmtpSetup>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Auto Email Service",
                    Description = "This service is used to send emails."
                });
            });
            Logger(services);
        }

        public void Logger(IServiceCollection services)
        {
            var logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("Logs/auto-email-service-.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            services.AddLogging();
            services.AddSerilog(logger);
            //logger.Information("Service is now listening...");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
