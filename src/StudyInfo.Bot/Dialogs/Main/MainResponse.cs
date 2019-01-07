using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AdaptiveCards;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.TemplateManager;
using Microsoft.Bot.Schema;
using StudyInfo.Bot.Constants;
using StudyInfo.Bot.Dialogs.Main.Resources;

namespace StudyInfo.Bot.Dialogs.Main
{
    public class MainResponses : TemplateManager
    {
        private static LanguageTemplateDictionary _responseTemplates = new LanguageTemplateDictionary
        {
            ["default"] = new TemplateIdMap
            {
                { ResponseIds.Introduction,
                    (context, data) =>
                    MessageFactory.Text(
                        text: MainStrings.INTRODUCTION,
                        ssml: MainStrings.INTRODUCTION,
                        inputHint: InputHints.AcceptingInput)
                },
                { ResponseIds.Cancelled,
                    (context, data) =>
                    MessageFactory.Text(
                        text: MainStrings.CANCELLED,
                        ssml: MainStrings.CANCELLED,
                        inputHint: InputHints.AcceptingInput)
                },
                { ResponseIds.Completed,
                    (context, data) =>
                    MessageFactory.Text(
                        text: MainStrings.COMPLETED,
                        ssml: MainStrings.COMPLETED,
                        inputHint: InputHints.AcceptingInput)
                },
                { ResponseIds.Confused,
                    (context, data) =>
                    MessageFactory.Text(
                        text: MainStrings.CONFUSED,
                        ssml: MainStrings.CONFUSED,
                        inputHint: InputHints.AcceptingInput)
                },
                { ResponseIds.Greeting,
                    (context, data) =>
                    MessageFactory.Text(
                        text: MainStrings.GREETING,
                        ssml: MainStrings.GREETING,
                        inputHint: InputHints.AcceptingInput)
                },
                 { ResponseIds.NameTeacher,
                    (context, data) =>
                    MessageFactory.Text(
                         text: string.Format(MainStrings.TEACHER, data.Course, data.Teacher),
                         ssml: string.Empty,
                         inputHint: InputHints.IgnoringInput)
                },
                { ResponseIds.Help, (context, data) => BuildHelpCard(context, data) },
                { ResponseIds.Intro, (context, data) => BuildIntroCard(context, data) },
                {ResponseIds.StudyTime, (conext, data) =>
                MessageFactory.Text(
                    text: string.Format(MainStrings.STUDYRESPONSE, data.Course, data.TotalStudyTime),
                    inputHint: InputHints.AcceptingInput)
                }
            }
        };

        internal Task PromptAsync(object locationPrompt, PromptOptions promptOptions)
        {
            throw new NotImplementedException();
        }

        public MainResponses()
        {
            Register(new DictionaryRenderer(_responseTemplates));
        }

        public static IMessageActivity BuildIntroCard(ITurnContext turnContext, dynamic data)
        {
            var introCard = File.ReadAllText(MainStrings.INTRO_PATH);
            var card = AdaptiveCard.FromJson(introCard).Card;
            var attachment = new Attachment(AdaptiveCard.ContentType, content: card);

            var response = MessageFactory.Attachment(attachment, ssml: card.Speak, inputHint: InputHints.AcceptingInput);
            return response;
        }

        public static IMessageActivity BuildHelpCard(ITurnContext turnContext, dynamic data)
        {
            var card = new HeroCard().ToAttachment();

            var response = MessageFactory.Attachment(card, inputHint: InputHints.AcceptingInput);

            response.SuggestedActions = new SuggestedActions
            {
                Actions = new List<CardAction>()
                {
                    new CardAction(type: ActionTypes.ImBack, title: "titel", value: "value"),
                    new CardAction(type: ActionTypes.ImBack, title: "titel", value: "value"),
                    new CardAction(type: ActionTypes.OpenUrl, title: "titel", value: "value"),
                },
            };
            return response;
        }

        public class ResponseIds
        {
            // Constants
            public const string Greeting = "greeting";
            public const string Introduction = "introduction";
            public const string NameTeacher = "nameTeacher";
            public const string Cancelled = "cancelled";
            public const string Completed = "completed";
            public const string Confused = "confused";
            public const string Help = "help";
            public const string Intro = "intro";
            public const string AskInfo = "info";
            public const string StudyTime = "studyTime";
        }
    }
}
