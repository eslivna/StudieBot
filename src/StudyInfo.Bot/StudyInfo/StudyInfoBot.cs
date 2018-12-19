using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using StudyInfo.Bot.Constants;
using StudyInfo.Bot.Domain.Course;
using StudyInfo.Bot.Helper;
using StudyInfo.Logic.Data;
using StudyInfo.Logic.Data.Domain.Course;
using StudyInfo.Logic.Data.Domain.Luis;

namespace StudyInfo.Bot.StudyInfo
{
    public class StudyInfoBot : IBot
    {
        /// <summary>
        /// Services configured from the ".bot" file.
        /// </summary>
        private readonly BotServices _services;
        private IDatabaseService _dbService;

        /// <summary>
        /// Initializes a new instance of the <see cref="NlpDispatchBot"/> class.
        /// </summary>
        /// <param name="services">Services configured from the ".bot" file.</param>
        public StudyInfoBot(BotServices services, IDatabaseService databaseService)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _dbService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));

            //if (!_services.QnAServices.ContainsKey(QnAMakerKey))
            //{
            //    throw new System.ArgumentException($"Invalid configuration. Please check your '.bot' file for a QnA service named '{DispatchKey}'.");
            //}

            if (!_services.LuisServices.ContainsKey(LuisKeyFor.HoGentGeneral))
            {
                throw new ArgumentException($"Invalid configuration. Please check your '.bot' file for a Luis service named '{LuisKeyFor.HoGentGeneral}'.");
            }

            if (!_services.LuisServices.ContainsKey(LuisKeyFor.TrainingCourses))
            {
                throw new ArgumentException($"Invalid configuration. Please check your '.bot' file for a Luis service named '{LuisKeyFor.TrainingCourses}'.");
            }
        }

        /// <summary>
        /// Every conversation turn for our NLP Dispatch Bot will call this method.
        /// There are no dialogs used, since it's "single turn" processing, meaning a single
        /// request and response, with no stateful conversation.
        /// </summary>
        /// <param name="turnContext">A <see cref="ITurnContext"/> containing all the data needed
        /// for processing this conversation turn. </param>
        /// <param name="cancellationToken">(Optional) A <see cref="CancellationToken"/> that can be used by other objects
        /// or threads to receive notice of cancellation.</param>
        /// <returns>A <see cref="Task"/> that represents the work queued to execute.</returns>
        public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (turnContext.Activity.Type == ActivityTypes.Message && !turnContext.Responded)
            {
                // Get the intent recognition result
                var recognizerResult = await _services.LuisServices[LuisKeyFor.Dispatch].RecognizeAsync(turnContext, cancellationToken);
                var topIntent = recognizerResult?.GetTopScoringIntent();
                turnContext.Activity.Text = recognizerResult.AlteredText ?? turnContext.Activity.Text;
                if (topIntent == null)
                {
                    await turnContext.SendActivityAsync("Unable to get the top intent.");
                }
                else
                {
                    await DispatchToTopIntentAsync(turnContext, topIntent, cancellationToken);
                }
            }
            else if (turnContext.Activity.Type == ActivityTypes.ConversationUpdate)
            {
                // Send a welcome message to the user and tell them what actions they may perform to use this bot
                if (turnContext.Activity.MembersAdded != null)
                {
                    await SendWelcomeMessageAsync(turnContext, cancellationToken);
                }
            }
            else
            {
                await turnContext.SendActivityAsync($"{turnContext.Activity.Type} event detected", cancellationToken: cancellationToken);
            }
        }

        /// <summary>
        /// On a conversation update activity sent to the bot, the bot will
        /// send a message to the any new user(s) that were added.
        /// </summary>
        /// <param name="turnContext">Provides the <see cref="ITurnContext"/> for the turn of the bot.</param>
        /// <param name="cancellationToken" >(Optional) A <see cref="CancellationToken"/> that can be used by other objects
        /// or threads to receive notice of cancellation.</param>
        /// <returns>>A <see cref="Task"/> representing the operation result of the Turn operation.</returns>
        private static async Task SendWelcomeMessageAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in turnContext.Activity.MembersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync($"Welcome to StudyInfo bot {member.Name}.", cancellationToken: cancellationToken);
                }
            }
        }

        /// <summary>
        /// Depending on the intent from Dispatch, routes to the right LUIS model or QnA service.
        /// </summary>
        private async Task DispatchToTopIntentAsync(ITurnContext context, (string intent, double score)? topIntent, CancellationToken cancellationToken = default(CancellationToken))
        {
            //const string qnaDispatchKey = "q_sample-qna";

            switch (topIntent.Value.intent)
            {
                case DispatchKeyFor.HoGentGeneral:
                    // var response = await DispatchToLuisModelAsync(context, LuisKeyFor.HoGentGeneral);

                    await SendSuggestedActionsAsync(context, default(CancellationToken));

                    // Here, you can add code for calling the hypothetical home automation service, passing in any entity information that you need
                    break;
                case DispatchKeyFor.TrainingCourses:
                    var result = await DispatchToLuisModelAsync(context, LuisKeyFor.TrainingCourses);
                    var responseText = string.Empty;
                    try
                    {
                        responseText = await CourseIntentionHandler.GetResponseTextAsync(_dbService, result);
                        await context.SendActivityAsync(responseText);
                    }
                    catch (Exception e)
                    {
                        await context.SendActivityAsync(e.Message);
                    }
                    
                    break;
                case DispatchKeyFor.None:
                    // You can provide logic here to handle the known None intent (none of the above).
                    // In this example we fall through to the QnA intent.
                    //case qnaDispatchKey:
                    //    await DispatchToQnAMakerAsync(context, QnAMakerKey);
                    break;

                default:
                    // The intent didn't match any case, so just display the recognition results.
                    await context.SendActivityAsync($"Dispatch intent: {topIntent.Value.intent} ({topIntent.Value.score}).");
                    break;
            }
        }

        /// <summary>
        /// Dispatches the turn to the request QnAMaker app.
        /// </summary>
        private async Task DispatchToQnAMakerAsync(ITurnContext context, string appName, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!string.IsNullOrEmpty(context.Activity.Text))
            {
                var results = await _services.QnAServices[appName].GetAnswersAsync(context);
                if (results.Any())
                {
                    await context.SendActivityAsync(results.First().Answer, cancellationToken: cancellationToken);
                }
                else
                {
                    await context.SendActivityAsync($"Couldn't find an answer in the {appName}.");
                }
            }
        }

        /// <summary>
        /// Dispatches the turn to the requested LUIS model.
        /// </summary>
        private async Task<LuisResult> DispatchToLuisModelAsync(ITurnContext context, string appName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = new Logic.Data.Domain.Luis.Entity();
            var intent = IntentType.None;
            try
            {
                var result = await _services.LuisServices[appName].RecognizeAsync<CourseRecognizerConvert>(context, cancellationToken);

                entity = new Logic.Data.Domain.Luis.Entity() { Type = result.Entities.Instance.Courses.FirstOrDefault().Type, Value = result.Entities.Courses[0][0] };
                intent = result.Intents.FirstOrDefault().Key;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return new LuisResult() { Entity = entity, Intent = intent };
        }

        private static async Task SendSuggestedActionsAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            var reply = turnContext.Activity.CreateReply("Het inschrijvingsgeld varieert naargelang of geniet van een beurs of niet. Wat voor soort student bent u ?");
            reply.SuggestedActions = new SuggestedActions()
            {
                Actions = new List<CardAction>()
                {
                    new CardAction() { Title = "Beursstudent", Type = ActionTypes.ImBack, Value = "Beursstudent" },
                    new CardAction() { Title = "Bijna-beursstudent ", Type = ActionTypes.ImBack, Value = "Bijna-beursstudent" },
                    new CardAction() { Title = "Niet-beursstudent", Type = ActionTypes.ImBack, Value = "Niet-beursstudent" },
                },
            };
            await turnContext.SendActivityAsync(reply, cancellationToken);
        }
    }
}

