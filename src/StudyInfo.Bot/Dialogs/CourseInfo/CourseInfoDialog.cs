using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using StudyInfo.Bot.Dialogs.Shared;
using StudyInfo.Bot.StudyInfo;
using StudyInfo.Logic.Data;
using System.Linq;
using StudyInfo.Logic.Data.Domain.Course;
using System;

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
                result = courseEntities.Where(c => c.AcademicYear == int.Parse(year[0]) && c.Term == int.Parse(semester[0])).ToList();

            var courseNames = string.Join("<br> ", result.Select(x => x.Course.ToString()).ToArray());

            await _responder.ReplyWith(sc.Context, CourseInfoResponse.ResponseIds.Courses,
                new
                {
                    result[0].AcademicYear,
                    result[0].Term,
                    result.Count,
                    courseNames
                });
            return await sc.EndDialogAsync();
        }

        private class DialogIds
        {
            public const string NamePrompt = "namePrompt";
            public const string EmailPrompt = "emailPrompt";
            public const string LocationPrompt = "locationPrompt";
        }


    }
}
