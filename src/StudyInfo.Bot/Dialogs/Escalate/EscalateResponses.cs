using System.Collections.Generic;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.TemplateManager;
using Microsoft.Bot.Schema;
using StudyInfo.Bot.Dialogs.Escalate.Resources;

namespace StudyInfo.Bot.Dialogs.Escalate
{
    public class EscalateResponses : TemplateManager
    {
        private LanguageTemplateDictionary _responseTemplates = new LanguageTemplateDictionary
        {
            ["default"] = new TemplateIdMap
            {
                { ResponseIds.SendEmailMessage, (context, data) => BuildEscalateCard(context, data) },
            }
        };

        public EscalateResponses()
        {
            Register(new DictionaryRenderer(_responseTemplates));
        }

        public static IMessageActivity BuildEscalateCard(ITurnContext turnContext, dynamic data)
        {
            var attachment = new HeroCard()
            {
                Text = EscalateString.EMAIL_INFO,
                Buttons = new List<CardAction>()
                {
                    new CardAction(type: ActionTypes.OpenUrl, title: "Contact us ", value: "mailto:fbo@hogent.be")
                },
            }.ToAttachment();

            return MessageFactory.Attachment(attachment, null, EscalateString.EMAIL_INFO, InputHints.AcceptingInput);
        }

        public class ResponseIds
        {
            public const string SendEmailMessage = "SendEmailMessage";
        }
    }
}
