using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using StudyInfo.Bot.Constants;
using StudyInfo.Bot.Dialogs.CourseInfo;
using StudyInfo.Bot.Dialogs.Escalate;
using StudyInfo.Bot.Dialogs.Main;
using StudyInfo.Bot.Dialogs.Shared;
using StudyInfo.Bot.Dialogs.Teacher.Resources;
using StudyInfo.Bot.Extensions;
using StudyInfo.Bot.Models;
using StudyInfo.Bot.StudyInfo;
using StudyInfo.Logic.Data;
using StudyInfo.Logic.Data.Domain.Course;

namespace StudyInfo.Bot.Dialogs.Dispatcher
{
    public class MainDialog : RouterDialog
    {
        private BotServices _services;
        private IDatabaseService _databaseService;

        private UserState _userState;
        private CourseInfoState _courseState;
        private ConversationState _conversationState;

        private readonly IStatePropertyAccessor<UserProfile> _userProfileAccessor;
        private readonly IStatePropertyAccessor<CourseInfoState> _courseAccessor;
        private MainResponses _responder = new MainResponses();

        public MainDialog(BotServices services, ConversationState conversationState, UserState userState, IDatabaseService databaseService, IBotTelemetryClient telemetryClient)
            : base(nameof(MainDialog))
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));

            _databaseService = databaseService;
            _conversationState = conversationState;
            _userProfileAccessor = conversationState.CreateProperty<UserProfile>(nameof(UserProfile));
            _courseAccessor = conversationState.CreateProperty<CourseInfoState>(nameof(CourseInfoState));
            _userState = userState;
            TelemetryClient = telemetryClient;

            AddDialog(new EscalateDialog(_services, _databaseService));
            AddDialog(new TeacherDialog(_services, _databaseService));
            AddDialog(new CourseInfoDialog(_services, _courseAccessor, _databaseService));
        }

        protected override async Task OnStartAsync(DialogContext dc, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _responder.ReplyWith(dc.Context, MainResponses.ResponseIds.Greeting);
            await Task.Delay(1000);
            await _responder.ReplyWith(dc.Context, MainResponses.ResponseIds.Introduction);
            await _responder.ReplyWith(dc.Context, MainResponses.ResponseIds.Intro);
        }

        protected override async Task RouteAsync(DialogContext dc, CancellationToken cancellationToken = default(CancellationToken))
        {
            _courseState = await _courseAccessor.GetAsync(dc.Context, () => new CourseInfoState());
            // Check dispatch result
            var dispatchResult = await _services.DispatchRecognizer.RecognizeAsync<DispatchModel>(dc, true, CancellationToken.None);
            if (!string.IsNullOrEmpty(dispatchResult.AlteredText))
                dc.Context.Activity.Text = dispatchResult.AlteredText;
            var intent = dispatchResult.TopIntent().intent;

            if (intent == DispatchModel.Intent.l_Training_Courses)
            {
                // If dispatch result is general luis model
                _services.LuisServices.TryGetValue(LuisKeyFor.TrainingCourses, out var luisService);

                if (luisService == null)
                {
                    throw new Exception("The specified LUIS Model could not be found in your Bot Services configuration.");
                }
                else
                {
                    var result = await luisService.RecognizeAsync<CourseModel>(dc, true, CancellationToken.None);
                    

                    if (result.Entities.Course != null)
                        _courseState.Courses = result.Entities?.Course[0];

                    if (result.Entities.Year != null)
                        _courseState.Year = result.Entities?.Year[0];

                    if (result.Entities.Semester != null)
                        _courseState.Semester = result.Entities?.Semester[0];

                    var generalIntent = result?.TopIntent().intent;

                    // switch on general intents
                    switch (generalIntent)
                    {
                        case CourseModel.Intent.Cancel:
                            {
                                // send cancelled response
                                await _responder.ReplyWith(dc.Context, ResponseIdFor.Cancelled);

                                // Cancel any active dialogs on the stack
                                await dc.CancelAllDialogsAsync();
                                break;
                            }
                        case CourseModel.Intent.Get_Name_Teacher:
                            {
                                // send teacher response
                                if (_courseState.Courses != null && _courseState.Courses.Count() == 1)
                                {
                                    var courseEntity = await _databaseService.Get<CourseDataEntity>(_courseState.Courses[0]);
                                    await _responder.ReplyWith(dc.Context, ResponseIdFor.NameTeacher, new { courseEntity.Course, courseEntity.Teacher });
                                }
                                break;
                            }
                        case CourseModel.Intent.GetAllCourses:
                            {
                                await dc.BeginDialogAsync(nameof(CourseInfoDialog));
                                break;
                            }

                        case CourseModel.Intent.Get_Number_Of_Credits:
                            {
                                // send credit response
                                await dc.BeginDialogAsync(nameof(TeacherDialog));
                                break;
                            }

                        case CourseModel.Intent.Get_Study_Time:
                            {
                                // send help response
                                await dc.BeginDialogAsync(nameof(TeacherDialog));
                                break;
                            }
                        case CourseModel.Intent.Escalte:
                            {
                                // start escalate dialog
                                await dc.BeginDialogAsync(nameof(EscalateDialog));
                                break;
                            }
                        case CourseModel.Intent.None:
                        default:
                            {
                                // No intent was identified, send confused message
                                await _responder.ReplyWith(dc.Context, ResponseIdFor.Confused);
                                break;
                            }
                    }
                }
            }
            else if (intent == DispatchModel.Intent.q_General)
            {
                _services.QnAServices.TryGetValue(QnAKeyFor.General, out var qnaService);

                if (qnaService == null)
                {
                    throw new Exception("The specified QnA Maker Service could not be found in your Bot Services configuration.");
                }
                else
                {
                    var answers = await qnaService.GetAnswersAsync(dc.Context);

                    if (answers != null && answers.Count() > 0)
                    {
                        await dc.Context.SendActivityAsync(answers[0].Answer);
                    }
                }
            }
            else
            {
                // If dispatch intent does not map to configured models, send "confused" response.
                await _responder.ReplyWith(dc.Context, ResponseIdFor.Confused);
            }
        }

        protected override async Task CompleteAsync(DialogContext dc, CancellationToken cancellationToken = default(CancellationToken))
        {
            // The active dialog's stack ended with a complete status
            await _responder.ReplyWith(dc.Context, ResponseIdFor.Completed);
        }
    }
    public class CardResponse
    {
        public string Text { get; set; }
    }
}