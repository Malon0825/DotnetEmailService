using AutoEmailService.Configurations;

namespace AutoEmailService
{
    public abstract class Program 
    {
        public static void Main(string[] args)
        {
            Task.Run(async () => await StartAsyncServiceHost(args)).Wait();
        }

        private static Task StartAsyncServiceHost(string[] args)
        {
            return CreateHostBuilder(args).RunConsoleAsync();
        }

        // Separate method for configuring services
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}