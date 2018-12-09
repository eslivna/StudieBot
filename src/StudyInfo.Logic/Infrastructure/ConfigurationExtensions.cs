using Microsoft.Extensions.Configuration;

namespace StudyInfo.Logic.Infrastructure
{
    public static class ConfigurationExtensions
    {
        public static IConfigurationRoot AddTableStorageServices(this IConfigurationRoot config,
            TableStorageConfiguration configuration)
        {
            TableStorageConfiguration.Resolve = () => configuration;
            return config;
        }
    }
}
