using System;

namespace StudyInfo.Logic.Infrastructure
{
    public class TableStorageConfiguration
    {
        public string ConnectionString { get; set; }

        public static Func<TableStorageConfiguration> Resolve = () => default(TableStorageConfiguration);
    }
}
