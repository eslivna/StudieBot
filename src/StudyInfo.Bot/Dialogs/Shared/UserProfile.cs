namespace StudyInfo.Bot.Dialogs.Shared
{
    public class UserProfile
    {
        public UserProfile(string name, string location = null)
        {
            UserName = name;
            Location = location;
        }

        public string UserName { get; set; }

        public string Location { get; set; }
    }
}
