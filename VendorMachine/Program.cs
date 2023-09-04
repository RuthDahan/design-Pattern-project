using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
namespace VendorMachine
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var host = CreateHostBuilder().Build();
            Application.Run(new Form1());
            
        }
        static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
           .ConfigureServices((context, services) =>
           {
               //  services.AddHelloServices(context.Configuration);

               services.AddSingleton<State, VendorPaymentMethod>();
               services.AddSingleton<State, VendorProcessProductMethod>();
               services.AddSingleton<State, VendorSelectionMethod>();
               //services.AddTransient<Form1>();
           });

    }
}