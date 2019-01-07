using Microsoft.Bot.Builder.TemplateManager;

namespace StudyInfo.Bot.Dialogs.AskCatalogus
{
    public class AskCatalogusResponses : TemplateManager
    {
        private static LanguageTemplateDictionary _responseTemplates = new LanguageTemplateDictionary
        {
            ["default"] = new TemplateIdMap
            { }
        };
        public AskCatalogusResponses()
        {
            Register(new DictionaryRenderer(_responseTemplates));
        }

        public class ResponseIds
        {
            public const string Courses = "courses";
        }
    }
}
