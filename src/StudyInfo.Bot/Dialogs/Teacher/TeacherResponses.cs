using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.TemplateManager;
using Microsoft.Bot.Schema;
using StudyInfo.Bot.Constants;
using StudyInfo.Bot.Dialogs.Teacher.Resources;

namespace StudyInfo.Bot.Dialogs.Teacher
{
    public class TeacherResponses : TemplateManager
    {
        private static LanguageTemplateDictionary _responseTemplates = new LanguageTemplateDictionary
        {
            ["default"] = new TemplateIdMap
            {
                {ResponseIdFor.NameTeacher, (context, data) => MessageFactory.Text(
                    text: string.Format(TeacherString.NAME_ANSWER),
                    ssml: string.Empty,
                    inputHint: InputHints.IgnoringInput)
                }
            }
        };

        public TeacherResponses()
        {
            Register(new DictionaryRenderer(_responseTemplates));
        }
    }
}
