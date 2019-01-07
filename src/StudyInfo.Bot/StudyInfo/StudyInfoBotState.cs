using Microsoft.Bot.Builder.Dialogs;

namespace StudyInfo.Bot.StudyInfo
{
    public class StudyInfoBotState : DialogState
    {
        public string[] CourseEntities { get; set; }
    }
}
