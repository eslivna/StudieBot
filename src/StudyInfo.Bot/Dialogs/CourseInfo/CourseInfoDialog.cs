using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using StudyInfo.Bot.Dialogs.Shared;
using StudyInfo.Bot.StudyInfo;
using StudyInfo.Logic.Data;
using System.Linq;
using Microsoft.Bot.Schema;
using StudyInfo.Bot.Dialogs.CourseInfo.Resources;
using System;
using StudyInfo.Logic.Domain.Course;

namespace StudyInfo.Bot.Dialogs.CourseInfo
{
    public class CourseInfoDialog : StudyInfoDialog
    {
        private static CourseInfoResponse _responder = new CourseInfoResponse();
        private IStatePropertyAccessor<CourseInfoState> _accessor;
        private CourseInfoState _state;
        private IDatabaseService _databaseService;

        public CourseInfoDialog(BotServices botServices, IStatePropertyAccessor<CourseInfoState> accessor, IDatabaseService databaseService) : base(botServices, databaseService, nameof(CourseInfoDialog))
        {
            _accessor = accessor;
            _databaseService = databaseService;
            InitialDialogId = nameof(CourseInfoDialog);

            var course = new WaterfallStep[]
            {
                SendCourses
            };
            AddDialog(new WaterfallDialog(InitialDialogId, course) { });
        }

        private async Task<DialogTurnResult> SendCourses(WaterfallStepContext sc, CancellationToken cancellationToken)
        {
            _state = await _accessor.GetAsync(sc.Context, () => new CourseInfoState());
            var semester = _state.Semester;
            string[] year = _state.Year; ;
            var courseEntities = await _databaseService.GetAll<CourseDataEntity>();
            var result = new List<CourseDataEntity>();

            if (year == null)
                year = new string[] { "1" };

            if (year[0] != null && semester[0] != null)
            {
                result = courseEntities.Where(c => c.AcademicYear == int.Parse(year[0]) && c.Term == int.Parse(semester[0])).ToList();
            }
            else if (semester[0] == null)
            {
                result = courseEntities.Where(c => c.AcademicYear == int.Parse(year[0])).ToList();
            }

            var courseNames = string.Join("<br> ", result.Select(x => x.Course.ToString()).ToArray());

            await _responder.ReplyWith(sc.Context, CourseInfoResponse.ResponseIds.Courses,
                new
                {
                    result[0].AcademicYear,
                    result[0].Term,
                    result.Count,
                    courseNames
                });

            var reply = GetSuggestions(sc, result.Select(x => x.Course.ToString()).ToList());

            await Task.Delay(3000);
            await sc.Context.SendActivityAsync(reply, cancellationToken);

            return await sc.EndDialogAsync();
        }

        private Activity GetSuggestions(WaterfallStepContext sc, List<string> courseNames)
        {
            //Get random indexes to get random course suggestions
            var random = new Random();
            var indexes = new int[3];
            for (var i = 0; i < 3; i++)
            {
                indexes[i] = random.Next(0, courseNames.Count);
            }

            var reply = sc.Context.Activity.CreateReply(CourseStrings.HINTS, sc.Context.Activity.Locale);
            reply.SuggestedActions = new SuggestedActions()
            {
                Actions = new List<CardAction>()
                {
                    new CardAction() { Title = $"Cursusinhoud {courseNames[indexes[0]]}", Type = ActionTypes.ImBack, Value = $"Cursusinhoud {courseNames[indexes[0]]}" },
                    new CardAction() { Title = $"Welke docent geeft {courseNames[indexes[1]]}", Type = ActionTypes.ImBack, Value = $"Welke docent geeft {courseNames[indexes[1]]}" },
                    new CardAction() { Title = $"Studietijd {courseNames[indexes[2]]}" , Type = ActionTypes.ImBack, Value = $"Hoeveel tijd heb ik nodig om {courseNames[indexes[2]]} te studeren" },
                },
            };

            return reply;
        }
    }
}
