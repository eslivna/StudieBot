using System;

namespace StudyInfo.Logic.Infrastructure
{
    public class SpellCheckConfiguration
    {
        public string EndPoint { get; set; }
        public string ApiKey { get; set; }

        public static Func<SpellCheckConfiguration> Resolve = () => default(SpellCheckConfiguration);
    }
}
