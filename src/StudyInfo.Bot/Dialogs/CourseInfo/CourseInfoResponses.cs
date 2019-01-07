using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.TemplateManager;
using Microsoft.Bot.Schema;
using StudyInfo.Bot.Dialogs.CourseInfo.Resources;

namespace StudyInfo.Bot.Dialogs.CourseInfo
{
    public class CourseInfoResponse : TemplateManager
    {
        private static LanguageTemplateDictionary _responseTemplates = new LanguageTemplateDictionary
        {
            ["default"] = new TemplateIdMap
            {{ResponseIds.Courses, (context, data) => MessageFactory.Text(
                    text: string.Format(CourseStrings.COURSE_YEAR_SEM, data.AcademicYear, data.Term, data.Count, data.courseNames),
                    ssml: string.Empty,
                    inputHint: InputHints.IgnoringInput)
                }
            }
        };
        public CourseInfoResponse()
        {
            Register(new DictionaryRenderer(_responseTemplates));
        }

        public class ResponseIds
        {
            public const string Courses = "courses";
        }
    }
}
