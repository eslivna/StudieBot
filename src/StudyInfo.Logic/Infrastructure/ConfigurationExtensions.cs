using Microsoft.Extensions.Configuration;

namespace StudyInfo.Logic.Infrastructure
{
    public static class ConfigurationExtensions
    {
        public static IConfigurationRoot AddTableStorageServices(this IConfigurationRoot config,TableStorageConfiguration configuration)
        {
            TableStorageConfiguration.Resolve = () => configuration;
            return config;
        }

        public static IConfigurationRoot AddSpellCheckServices(this IConfigurationRoot config, SpellCheckConfiguration configuration)
        {
            SpellCheckConfiguration.Resolve = () => configuration;
            return config;
        }
    }
}
