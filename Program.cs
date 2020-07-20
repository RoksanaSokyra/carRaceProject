using Microsoft.Extensions.DependencyInjection;
using RaceSimulator.Data;
using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using RaceSimulator.Services;
using RaceSimulator.Data.Entities;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Xsl;

namespace RaceSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetRequiredService<ConsoleApplication>().Run();
            
        }

        static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddDbContext<AppDbContext>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IOwnerService, OwnerService>();

            services.AddSingleton<ConsoleApplication>();
            // options =>
            //options.UseSqlServer(ConfigurationManager.
            //ConnectionStrings["RaceDatabase"].ConnectionString));
            //services.AddScoped<ICarService, CarService>();
            return services;
        }
    }
}
