using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using StudyInfo.Bot.Dialogs.Shared;
using StudyInfo.Bot.StudyInfo;
using StudyInfo.Logic.Data;

namespace StudyInfo.Bot.Dialogs.CourseInfo
{
    public class CourseInfoDialog : StudyInfoDialog
    {
        private static CourseInfoResponse _responder = new CourseInfoResponse();
        private IStatePropertyAccessor<CourseInfoState> _accessor;
        private CourseInfoState _state;

        public CourseInfoDialog(BotServices botServices, IDatabaseService databaseService,  IBotTelemetryClient telemetryClient) : base(botServices, databaseService, nameof(CourseInfoDialog))
        {
        }


    }
}
