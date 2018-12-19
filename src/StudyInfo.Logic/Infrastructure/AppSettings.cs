namespace StudyInfo.Logic.Infrastructure
{
    public class AppSettings
    {
        public TableStorageConfiguration TableStorageConfiguration { get; set; }
        public SpellCheckConfiguration SpellCheckConfiguration { get; set; }
        public string StorageAccesKey { get; set; }
        public string StorageAccountName { get; set; }
    }
}
