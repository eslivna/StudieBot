using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using StudyInfo.ConsoleApp.StorageEngine;
using StudyInfo.Logic.Infrastructure;

namespace StudyInfo.ConsoleApp
{
    public class Program
    {
        private static IConfigurationRoot _config;

        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            _config = builder.Build();

            var appSettings = _config.Get<AppSettings>();
            _config.AddTableStorageServices(appSettings.TableStorageConfiguration);
            

            Console.WriteLine("Console application started");
            var providor = new StorageProvider();
            providor.Process();
            Console.ReadKey();
        }
    }
}