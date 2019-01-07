using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.TemplateManager;
using Microsoft.Bot.Schema;
using StudyInfo.Bot.Dialogs.EnrolmentFee.Resources;

namespace StudyInfo.Bot.Dialogs.EnrolmentFee
{
    public class EnrolmentFeeResponses : TemplateManager
    {
        private static LanguageTemplateDictionary _responseTemplates = new LanguageTemplateDictionary
        {
            ["default"] = new TemplateIdMap
            {
                { ResponseIds.StudentTypePrompt,
                    (context, data) =>
                    MessageFactory.Text(
                        text: EnrolmentFeeStrings.ASK_STUDENT_TYPE,
                        ssml: EnrolmentFeeStrings.ASK_STUDENT_TYPE,
                        inputHint: InputHints.ExpectingInput)
                }
            }
        };

        public EnrolmentFeeResponses()
        {
            Register(new DictionaryRenderer(_responseTemplates));
        }

        public class ResponseIds
        {
            public const string StudentTypePrompt = "studentTypePrompt";
        }
    }
}
