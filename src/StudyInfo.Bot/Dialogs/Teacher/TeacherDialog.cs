using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using StudyInfo.Bot.Constants;
using StudyInfo.Bot.Dialogs.Shared;
using StudyInfo.Bot.StudyInfo;
using StudyInfo.Logic.Data;

namespace StudyInfo.Bot.Dialogs.Teacher.Resources
{
    public class TeacherDialog : StudyInfoDialog
    {
        private IDatabaseService _databaseService;
        private BotServices _botServices;
        private static TeacherResponses _response = new TeacherResponses();

        public TeacherDialog(BotServices botServices, IDatabaseService databaseService) : base(botServices, databaseService, nameof(TeacherDialog))
        {
            _databaseService = databaseService;
            _botServices = botServices;

            InitialDialogId = nameof(TeacherDialog);
            var escalate = new WaterfallStep[]
            {
                SendNameTeacher,
            };

            AddDialog(new WaterfallDialog(InitialDialogId, escalate));
        }

        private async Task<DialogTurnResult> SendNameTeacher(WaterfallStepContext sc, CancellationToken cancellationToken)
        {
            await _response.ReplyWith(sc.Context, ResponseIdFor.NameTeacher);
            return await sc.EndDialogAsync();
        }

    }
}
