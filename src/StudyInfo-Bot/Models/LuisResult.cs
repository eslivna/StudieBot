namespace StudyInfo.Bot.Models
{
    public class LuisResult
    {
        public Entity Entity { get; set; }

        public string Intent { get; set; }
    }

    public class Entity
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
